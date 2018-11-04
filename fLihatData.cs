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
using System.Drawing.Printing;

namespace WindowsFormsApplication2
{
    public partial class fLihatData : Form
    {
        public fLihatData()
        {
            InitializeComponent();
        }

        MySqlConnection strConnection = new MySqlConnection("Server=localhost;DATABASE=alumni;UID=root;Pwd=");
        string nik;

        

        private void fLihatData_Load(object sender, EventArgs e)
        {
            strConnection.Open();
            loadData(nik);
            dataHeader();
            strConnection.Close();
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
                label2.Text = "APLIKASI DATA ALUMNI " + kolom["nama"].ToString();
                string foto = kolom["logo"].ToString();
                Image image = Image.FromFile(appPath + foto);
                pictureBox1.Image = image;
            }

            koneksiB.Close();
        }

        public void loadData(string nik)
        {
            MySqlCommand cmd;
            cmd = strConnection.CreateCommand();
            cmd.CommandText = "SELECT  nomor_induk as NIS, nama as Nama, tahun_keluar as 'Alumni Tahun', alamat as Alamat, telepon as Telepon, data_1 as Ijazah, data_2 as SKHUN, data_3 as SHU , data_4 as foto_siswa FROM data_alumni WHERE (data_1 <> '' OR data_4 <> '' OR data_2 <> '' OR data_3 <> '' OR data_3 <> '') AND (nomor_induk like '%" + nik + "%' OR nama like '%" + nik + "%')" ;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            int k = dataGridView1.RowCount - 1;
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
         
                nik = textBoxCari.Text;
                loadData(nik);
                textBoxCari.Text = "";
        }

       

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string nomor_induk = row.Cells[0].Value.ToString();
                string nama = row.Cells[1].Value.ToString();
                string tahun_akhir = row.Cells[2].Value.ToString();
                string alamat = row.Cells[3].Value.ToString();
                string telepon = row.Cells[4].Value.ToString();
                string data_1 = row.Cells[5].Value.ToString();
                string data_2 = row.Cells[6].Value.ToString();
                string data_3 = row.Cells[7].Value.ToString();
                string data_4 = row.Cells[8].Value.ToString();
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label15.Text = nomor_induk.Trim();
                label16.Text = nama.Trim();
                label17.Text = tahun_akhir.Trim();
                label18.Text = alamat.Trim();
                label19.Text = telepon.Trim();
                label20.Text = data_1.Trim();
                label21.Text = data_2.Trim();
                label22.Text = data_3.Trim();
                label26.Text = data_4.Trim();
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Ijazah\";
                Image image = Image.FromFile(appPath + label20.Text);
                pictureBoxIjasah.Image = image;
                string appPath2 = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\SKHUN\";
                Image image2 = Image.FromFile(appPath2 + label21.Text);
                pictureBoxSKHUN.Image = image2;
                string appPath3 = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\SHU\";
                Image image3 = Image.FromFile(appPath3 + label22.Text);
                pictureBoxSHU.Image = image3;
                string appPath4 = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Siswa\";
                Image image4 = Image.FromFile(appPath4 + label26.Text);
                pictureBoxSiswa.Image = image4;
            }
        }
        private void PrintPageIjazah(object o, PrintPageEventArgs e)
        {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Ijazah\";
                System.Drawing.Image img = System.Drawing.Image.FromFile(appPath + label20.Text);
                Point loc = new Point(100, 100);
                e.Graphics.DrawImage(img, loc);
        }

        private void PrintPageSKHUN(object o, PrintPageEventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\SKHUN\";
            System.Drawing.Image img = System.Drawing.Image.FromFile(appPath + label21.Text);
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }

        private void PrintPageSHU(object o, PrintPageEventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\SHU\";
            System.Drawing.Image img = System.Drawing.Image.FromFile(appPath + label22.Text);
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }

        private void buttonIjazah_Click(object sender, EventArgs e)
        {
            if (label20.Text == "url")
            {
                MessageBox.Show("Pilih terlebih dahulu data profile !");
            }
            else
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPageIjazah;
                pd.Print();
            }
        }

        private void buttonSKHUN_Click(object sender, EventArgs e)
        {
            if (label21.Text == "url")
            {
                MessageBox.Show("Pilih terlebih dahulu data profile !");
            }
            else
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPageSKHUN;
                pd.Print();
            }
        }

        private void buttonSHU_Click(object sender, EventArgs e)
        {
            if (label22.Text == "url")
            {
                MessageBox.Show("Pilih terlebih dahulu data profile !");
            }
            else
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPageSHU;
                pd.Print();
            }
        }

        private void fLihatData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        
        private void textBoxCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCari_Click(this, new EventArgs());
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}
