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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            
            
        }
      
        MySqlConnection strConnection = new MySqlConnection("Server=localhost;DATABASE=alumni;UID=root;Pwd=");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string usr = textBoxUser.Text.ToString();
                string psw = textBoxPass.Text.ToString();
                string id_usr = "";
                string nm_usr = "";
                string username = "";
                string koneksi = "server=localhost;database=alumni;uid=root;password=";
                MySqlConnection koneksiB = new MySqlConnection(koneksi);
                MySqlCommand com = new MySqlCommand("select * from pengguna where uname='" + usr + "' and pass='" + psw + "'", koneksiB);
                MySqlDataAdapter adap = new MySqlDataAdapter(com);
                DataTable table = new DataTable();
                adap.Fill(table);
                koneksiB.Open();
                foreach (DataRow kolom in table.Rows)
                {
                    id_usr = kolom["id_pengguna"].ToString();
                    nm_usr = kolom["nama"].ToString();
                    username = kolom["uname"].ToString();
                }
                if (table.Rows.Count > 0)
                {
                    Form1 f1 = new Form1();
                   
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password atau Username salah !!!");
                }
                koneksiB.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            
        }

        public void dataHeader()
        {
           
        }

        

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
