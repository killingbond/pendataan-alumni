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
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
           
        }

     
        

        private void buttonAlumni_Click(object sender, EventArgs e)
        {
           
            fdataAlumni Fdataalumni = new fdataAlumni();
            Fdataalumni.Show();
            this.Hide();
        }

        private void buttonLihat_Click(object sender, EventArgs e)
        {
            fLihatData flihatdata = new fLihatData();
            flihatdata.Show();
            this.Hide();

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                var formlogin = new formLogin();
                formlogin.Closed += (s, args) => this.Close();


                formlogin.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_profile form_profile = new Form_profile();
            form_profile.Show();
            this.Hide();
        }

        public void load()
        {
            
            string appPath  = AppDomain.CurrentDomain.BaseDirectory + @"Foto\\Profile\\";

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

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            FormImport formimport = new FormImport();
            formimport.ShowDialog();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fdataAlumni Fdata = new fdataAlumni();
            Fdata.Show();
            this.Hide();
        }

        private void rectangleShape1_Click_1(object sender, EventArgs e)
        {

        }

      
      
 

       
    }
}
