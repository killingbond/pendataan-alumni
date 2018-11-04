using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
namespace WindowsFormsApplication2
{
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }

        MySqlConnection strConnection = new MySqlConnection("Server=localhost;DATABASE=alumni;UID=root;Pwd=");

     

       

        private void FormImport_Load(object sender, EventArgs e)
        {

        }

        private void buttonbrowseBackUp_Click(object sender, EventArgs e)
        {
            SaveFileDialog backup = new SaveFileDialog();
            backup.Title = "BackUp Database";
            backup.Filter = "sql files (*.sql)|*.sql";
            if (backup.ShowDialog() == DialogResult.OK)
            {
                string path = backup.FileName;
                textBoxpathBackUp.Text = path;
                path = path.Replace("\\", "/");
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if (textBoxpathBackUp.Text == "")
            {
                MessageBox.Show("Mohon Isi File Destinasi !");
            }
            else
            {
                backup();
            }
        }

        private void backup()
        {
           /*
            try
            {

                //string constring = "server='"+ textBoxServer.Text + "';user='"+ textBoxUser.Text +"';pwd='"+ textBoxPass.Text +"';database='" + textBoxDB.Text +"';";
                string constring = "server=localhost; user=root; pwd=; database=krt_rumahsakit";
                //string file = textBoxDestinasi.Text ;
                string nama = textBoxpathBackUp.Text;

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(nama);
                            conn.Close();
                        }
                    }
                }
                MessageBox.Show("Data Berhasil di Backup");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            * */
             
        }

        private void buttonBrowseRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog restore = new OpenFileDialog();
            restore.Title = "Restore Database";
            restore.Filter = "sql files (*.sql)|*.sql";
            if (restore.ShowDialog() == DialogResult.OK)
            {
                string path = restore.FileName;
                textBoxPathOpenFileRestore.Text = path;
                path = path.Replace("\\", "/");
            }
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            restore();
        }

        private void restore()
        {
            /*
            string constring = "server=localhost; user=root; pwd=; database=krt_rumahsakit";
            string file = textBoxPathOpenFileRestore.Text;

            if (file == "")
            {
                MessageBox.Show("Mohon Isi File Destinasi !");
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                        }
                    }
                }
                MessageBox.Show("Data Berhasil di Restore");
            }
             * */
        }

        private void rectangleShape1_Click_1(object sender, EventArgs e)
        {

        }

    
 


    }
}
