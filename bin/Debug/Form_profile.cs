using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form_profile : Form
    {
        public Form_profile()
        {
            InitializeComponent();
            openFileImage.Title = "Open Image";
            openFileImage.Filter = "JPG image (.jpg) | *.jpg";
            
        }

        MySqlConnection koneksiB = new MySqlConnection("server=localhost;database=alumni;uid=root;password=");

        private void buttonUbahNama_Click(object sender, EventArgs e)
        {
            if (textBoxNama.Text == "")
            {
                MessageBox.Show("Isi terlebih dahulu data yang akan diubah !");
            }
            else
            {

                koneksiB.Open();
                MySqlCommand cmd;
                cmd = koneksiB.CreateCommand();
                cmd.CommandText = "UPDATE profile SET nama=@nama WHERE id_profile=1";
                cmd.Parameters.AddWithValue("@nama", textBoxNama.Text);
                MessageBox.Show("Data telah diubah");
                cmd.ExecuteNonQuery();
                koneksiB.Close();
                load();
                dataHeader();
            }
        }


        public void dataHeader()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Profile\";
            string koneksi = "server=localhost;database=alumni;uid=root;password=";
            MySqlConnection koneksiB = new MySqlConnection(koneksi);
            MySqlCommand com = new MySqlCommand("select nama,logo from profile where id_profile = 1", koneksiB);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            DataTable table = new DataTable();
            adap.Fill(table);
            koneksiB.Open();
            foreach (DataRow kolom in table.Rows)
            {
                label3.Text = "APLIKASI DATA ALUMNI " + kolom["nama"].ToString();
                string foto = kolom["logo"].ToString();
                Image image = Image.FromFile(appPath + foto);
                pictureBox2.Image = image;
            }

            koneksiB.Close();
        }

        private void Form_profile_Load(object sender, EventArgs e)
        {
            load();
            dataHeader();
        }

        public void load()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Profile\";


            MySqlCommand com = new MySqlCommand("select nama,logo from profile where id_profile = 1", koneksiB);
            MySqlDataAdapter adap = new MySqlDataAdapter(com);
            DataTable table = new DataTable();
            adap.Fill(table);
            koneksiB.Open();
            foreach (DataRow kolom in table.Rows)
            {
                textBoxNama.Text = kolom["nama"].ToString();
                string foto = kolom["logo"].ToString();
                Image image = Image.FromFile(appPath + foto);
                pictureBox1.Image = image;
                labelFoto.Text = foto;
            }

            koneksiB.Close();
        }
        private void Form_profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void buttonUbahFoto_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Profile\";
                //get path image
                DateTime dt = DateTime.Now; // Or whatever
                string tahun = dt.ToString("yyyyMMddHHmmss");

                string iName = tahun + openFileImage.SafeFileName;
                string filepath = openFileImage.FileName;
                File.Copy(filepath, appPath + iName);
                //show imagepath
                koneksiB.Open();
                MySqlCommand cmd;
                cmd = koneksiB.CreateCommand();
                cmd.CommandText = "UPDATE profile SET logo=@logo WHERE id_profile=1";
                cmd.Parameters.AddWithValue("@logo", iName);


                MessageBox.Show("Foto telah Berhasil diubah");

                cmd.ExecuteNonQuery();
                koneksiB.Close();
                load();
                dataHeader();
            }
        }

       

       
    }
}
