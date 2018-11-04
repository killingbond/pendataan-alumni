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
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication2
{
    public partial class fdataAlumni : Form
    {
        MySqlConnection strConnection = new MySqlConnection("Server=localhost;DATABASE=alumni;UID=root;Pwd=");
        bool ubahdata = true;
        string nik;

        public fdataAlumni()
        {
            InitializeComponent();
            openFileImage.Title = "Open Image";
            openFileImage.Filter = "JPG image (.jpg) | *.jpg";
            openFileImage1.Filter = "JPG image (.jpg) | *.jpg";
            openFileImage2.Filter = "JPG image (.jpg) | *.jpg";
            openFileImage3.Filter = "JPG image (.jpg) | *.jpg";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            string det = "01/08/1945 14:50:50.42";
            DateTime bk = Convert.ToDateTime(det);
            dateTimePicker1.MinDate = bk;
            dateTimePicker1.MaxDate = DateTime.Now;
          
        }

        private void fdataAlumni_Load(object sender, EventArgs e)
        {
            string DateString = "2000";
            dateTimePicker1.Value = DateTime.ParseExact(DateString, "yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
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
            cmd.CommandText = "SELECT  nomor_induk as NIS, nama as Nama, tahun_keluar as 'Alumni Tahun', alamat as Alamat, telepon as Telepon, data_1 as Ijazah, data_2 as SKHUN, data_3 as SHU, data_4 as Foto  FROM data_alumni WHERE nomor_induk like '%" + nik + "%' OR alamat like '%" + nik + "%' OR tahun_keluar like '%" + nik + "%' OR nama like '%" + nik + "%'";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;     
            int k = dataGridView1.RowCount - 1;
         
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 100;
            MySqlCommand cmd2;
            cmd2 = strConnection.CreateCommand();
            cmd2.CommandText = "SELECT  nomor_induk as NIS, nama as Nama, tahun_keluar as 'Alumni Tahun', alamat as Alamat, telepon as Telepon FROM data_alumni WHERE nomor_induk like '%" + nik + "%' OR nama like '%" + nik + "%'OR tahun_keluar like '%" + nik + "%'OR alamat like '%" + nik + "%'";
            MySqlDataAdapter adap2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adap2.Fill(ds2);
            dataGridView3.DataSource = ds2.Tables[0].DefaultView;
          
        }

        public void loadData2(string nik)
        {
            MySqlCommand cmd;
            cmd = strConnection.CreateCommand();
            cmd.CommandText = "SELECT  nomor_induk as NIS, nama as Nama, tahun_keluar as 'Alumni Tahun', alamat as Alamat, telepon as Telepon, data_1 as Ijazah, data_2 as SKHUN, data_3 as SHU, data_4 as Foto  FROM data_alumni WHERE (data_1='' OR data_2='' OR data_3='' OR data_4='') AND (nomor_induk like '%" + nik + "%' OR nama like '%" + nik + "%' OR alamat like '%" + nik + "%' OR tahun_keluar like '%" + nik + "%')";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            MySqlCommand cmd2;
            cmd2 = strConnection.CreateCommand();
            cmd2.CommandText = "SELECT  nomor_induk as NIS, nama as Nama, tahun_keluar as 'Alumni Tahun', alamat as Alamat, telepon as Telepon FROM data_alumni WHERE (data_1='' OR data_2='' OR data_3='' OR data_4='') AND (nomor_induk like '%" + nik + "%' OR nama like '%" + nik + "%' OR alamat like '%" + nik + "%' OR tahun_keluar like '%" + nik + "%')";
            MySqlDataAdapter adap2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adap2.Fill(ds2);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView3.DataSource = ds2.Tables[0].DefaultView;
            int k = dataGridView1.RowCount - 1;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 100;


        }

        private void buttonIjasah_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Ijazah\";
                //get path image
                DateTime dt = DateTime.Now; // Or whatever
                string tahun = dt.ToString("yyyyMMddHHmmss");

                string iName = tahun + openFileImage.SafeFileName;
                string filepath = openFileImage.FileName;
                File.Copy(filepath, appPath + iName);
                //show imagepath
                textPath.Text = iName;
                ceklis();
            }
        }



        private void buttonShhun_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileImage1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\SKHUN\";
                //get path image
                DateTime dt = DateTime.Now; // Or whatever
                string tahun = dt.ToString("yyyyMMddHHmmss");

                string iName = tahun + openFileImage1.SafeFileName;
                string filepath = openFileImage1.FileName;
                File.Copy(filepath, appPath + iName);
                //show imagepath
                textPath1.Text = iName;
                ceklis();
            }

        }


        private void buttonSHU_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileImage2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\SHU\";
                //get path image
                DateTime dt = DateTime.Now; // Or whatever
                string tahun = dt.ToString("yyyyMMddHHmmss");

                string iName = tahun + openFileImage2.SafeFileName;
                string filepath = openFileImage2.FileName;
                File.Copy(filepath, appPath + iName);
                //show imagepath
                textPath2.Text = iName;
                ceklis();
            }
        }

       


        private void enabledon()
        {
            textBoxno.Enabled = true;
            textBoxnama.Enabled = true;
            textBoxalamat.Enabled = true;
            textBoxtelepon.Enabled = true;
            dateTimePicker1.Enabled = true;
            buttonIjasah.Enabled = true;
            buttonSHU.Enabled = true;
            buttonSkhun.Enabled = true;
            buttonSimpan.Enabled = true;
            buttonBatal.Enabled = true;
            buttonFoto.Enabled = true;
        }
        private void enabledoff()
        {
            textBoxno.Enabled = false;
            textBoxnama.Enabled = false;
            textBoxalamat.Enabled = false;
            textBoxtelepon.Enabled = false;
            dateTimePicker1.Enabled = false;
            buttonIjasah.Enabled = false;
            buttonSHU.Enabled = false;
            buttonSkhun.Enabled = false;
            buttonSimpan.Enabled = false;
            buttonBatal.Enabled = false;
            buttonFoto.Enabled = false;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            ubahdata = false;
            enabledon();
            buttonHapus.Enabled = false;
            buttonUbah.Enabled = false;
            buttonRefresh.Enabled = false;
            buttonCari.Enabled = false;
            buttonTambah.Enabled = false;
            refresh();
        }

        private void buttonBatal_Click(object sender, EventArgs e)
        {
            refresh();
            enabledoff();
            buttonHapus.Enabled = true;
            buttonUbah.Enabled = true;
            buttonRefresh.Enabled = true;
            buttonCari.Enabled = true;
            buttonTambah.Enabled = true;
        }

        private void refresh()
        {
            textBoxno.Clear();
            textBoxnama.Clear();
            textBoxalamat.Clear();
            string DateString = "2000";
            dateTimePicker1.Value = DateTime.ParseExact(DateString, "yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
            textBoxtelepon.Clear();
            textPath.Text = "";
            textPath1.Text = "";
            textPath2.Text = "";
            textPath3.Text = "";
            ceklis();

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            nik = "";
            refresh();
            loadData(nik);
            textBoxCari.Clear();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (ubahdata == false)
            {
                if (textBoxno.Text == "" || textBoxnama.Text == "" || textBoxalamat.Text == "" || textBoxtelepon.Text == "" || textPath.Text == "" || textPath1.Text == "" || textPath2.Text == "" || textPath3.Text == "")
                {
                    MessageBox.Show("Isi Terlebih Dahulu");
                }
                else
                {
                    string theDate = dateTimePicker1.Value.ToString("yyyy");
                    strConnection.Open();
                    MySqlCommand cmd;
                    cmd = strConnection.CreateCommand();
                    cmd.CommandText = "INSERT INTO data_alumni (nomor_induk,nama,tahun_keluar,alamat,telepon,data_1,data_2,data_3,data_4) VALUES (@nomor_induk,@nama,@tahun_keluar,@alamat,@telepon,@data_1,@data_2,@data_3,@data_4)";
                    cmd.Parameters.AddWithValue("@nomor_induk", textBoxno.Text);
                    cmd.Parameters.AddWithValue("@nama", textBoxnama.Text);
                    cmd.Parameters.AddWithValue("@tahun_keluar", theDate);
                    cmd.Parameters.AddWithValue("@alamat", textBoxalamat.Text);
                    cmd.Parameters.AddWithValue("@telepon", textBoxtelepon.Text);
                    cmd.Parameters.AddWithValue("@data_1", textPath.Text);
                    cmd.Parameters.AddWithValue("@data_2", textPath1.Text);
                    cmd.Parameters.AddWithValue("@data_3", textPath2.Text);
                    cmd.Parameters.AddWithValue("@data_4", textPath3.Text);
                    MessageBox.Show("Data telah disimpan");
                    cmd.ExecuteNonQuery();
                    if (label14.Text == "")
                    {
                        loadData(nik);
                    }
                    else
                    {
                        loadData2(nik);
                    }
                    
                    refresh();
                    enabledoff();
                    buttonHapus.Enabled = true;
                    buttonUbah.Enabled = true;
                    buttonRefresh.Enabled = true;
                    buttonCari.Enabled = true;
                    buttonTambah.Enabled = true;
                    strConnection.Close();
                }
            }
            else
            {

                if (textBoxno.Text == "" || textBoxnama.Text == "" || textBoxalamat.Text == "" || textBoxtelepon.Text == "" || textPath.Text == "" || textPath1.Text == "" || textPath2.Text == "")
                {
                    MessageBox.Show("Pilih terlebih dahulu data yang akan diubah !");
                }
                else
                {
                    string theDate = dateTimePicker1.Value.ToString("yyyy");
                    strConnection.Open();
                    MySqlCommand cmd;
                    cmd = strConnection.CreateCommand();
                    cmd.CommandText = "UPDATE data_alumni SET nomor_induk=@nomor_induk,nama=@nama,tahun_keluar=@tahun_keluar,alamat=@alamat,telepon=@telepon,data_1=@data_1,data_2=@data_2,data_3=@data_3,data_4=@data_4 WHERE nomor_induk=@nomor_induk";
                    cmd.Parameters.AddWithValue("@nomor_induk", textBoxno.Text);
                    cmd.Parameters.AddWithValue("@nama", textBoxnama.Text);
                    cmd.Parameters.AddWithValue("@tahun_keluar", theDate);
                    cmd.Parameters.AddWithValue("@alamat", textBoxalamat.Text);
                    cmd.Parameters.AddWithValue("@telepon", textBoxtelepon.Text);
                    cmd.Parameters.AddWithValue("@data_1", textPath.Text);
                    cmd.Parameters.AddWithValue("@data_2", textPath1.Text);
                    cmd.Parameters.AddWithValue("@data_3", textPath2.Text);
                    cmd.Parameters.AddWithValue("@data_4", textPath3.Text);
                    MessageBox.Show("Data telah diubah");
                    cmd.ExecuteNonQuery();

                    if (label14.Text == "")
                    {
                        loadData(nik);
                    }
                    else
                    {
                        loadData2(nik);
                    }
                    strConnection.Close();
                    refresh();
                    enabledoff();
                    buttonHapus.Enabled = true;
                    buttonTambah.Enabled = true;
                    buttonRefresh.Enabled = true;
                    buttonCari.Enabled = true;
                    buttonUbah.Enabled = true;
                }
            }
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            if (textBoxno.Text == "" || textBoxnama.Text == "" || textBoxalamat.Text == "" || textBoxtelepon.Text == "" )
            {
                MessageBox.Show("Pilih terlebih dahulu data yang akan diubah !");
            }
            else
            {

                ubahdata = true;
                enabledon();
                buttonHapus.Enabled = false;
                buttonTambah.Enabled = false;
                buttonRefresh.Enabled = false;
                buttonCari.Enabled = false;
                buttonUbah.Enabled = false;
                ceklis();
            }
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
                string data_2= row.Cells[6].Value.ToString();
                string data_3 = row.Cells[7].Value.ToString();
                string data_4 = row.Cells[8].Value.ToString();
              

                textBoxno.Text = nomor_induk.Trim();
                textBoxnama.Text = nama.Trim();
                string waktu = tahun_akhir.Trim();
                textBoxalamat.Text = alamat.Trim();
                textBoxtelepon.Text = telepon.Trim();
                textPath.Text = data_1.Trim();
                textPath1.Text = data_2.Trim();
                textPath2.Text = data_3.Trim();
                textPath3.Text = data_4.Trim();
                ceklis();
                dateTimePicker1.Value = DateTime.ParseExact(waktu, "yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);

                
                   
            }
        }

        public void ceklis()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\logo\";
            if (textPath.Text == "")
            {
                Image image = Image.FromFile(appPath + "cross.png");
                pictureBox2.Image = image;
            }
            else
            {
                Image image = Image.FromFile(appPath + "ceklis.png");
                pictureBox2.Image = image;
            }
            if (textPath1.Text == "")
            {
                Image image = Image.FromFile(appPath + "cross.png");
                pictureBox3.Image = image;
            }
            else
            {
                Image image = Image.FromFile(appPath + "ceklis.png");
                pictureBox3.Image = image;
            }
            if (textPath2.Text == "")
            {
                Image image = Image.FromFile(appPath + "cross.png");
                pictureBox4.Image = image;
            }
            else
            {
                Image image = Image.FromFile(appPath + "ceklis.png");
                pictureBox4.Image = image;
            }
            if (textPath3.Text == "")
            {
                Image image = Image.FromFile(appPath + "cross.png");
                pictureBox5.Image = image;
            }
            else
            {
                Image image = Image.FromFile(appPath + "ceklis.png");
                pictureBox5.Image = image;
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            if (textBoxno.Text == "")
            {
                MessageBox.Show("Pilih terlebih dahulu data yang akan dihapus !");
            }
            else
            {
                string title = "KONFIRMASI HAPUS DATA";
                string message = "Anda Yakin akan menghapus data ini ?";
                DialogResult result =
                MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result != DialogResult.OK)
                {
                    return;
                }
                strConnection.Open();
                MySqlCommand cmd;
                cmd = strConnection.CreateCommand();
                cmd.CommandText = "DELETE from data_alumni WHERE nomor_induk=@nomor_induk";
                cmd.Parameters.AddWithValue("@nomor_induk", textBoxno.Text);
                MessageBox.Show("Data telah dihapus");
                cmd.ExecuteNonQuery();
                loadData(nik);
                strConnection.Close();
                refresh();
            }
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            
                nik = textBoxCari.Text;
                loadData(nik);
                textBoxCari.Text = "";
              
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void fdataAlumni_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void buttonFoto_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileImage3.ShowDialog();
            if (result == DialogResult.OK)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Foto\Siswa\";
                //get path image
                DateTime dt = DateTime.Now; // Or whatever
                string tahun = dt.ToString("yyyyMMddHHmmss");

                string iName = tahun + openFileImage3.SafeFileName;
                string filepath = openFileImage3.FileName;
                File.Copy(filepath, appPath + iName);
                //show imagepath
                textPath3.Text = iName;
                ceklis();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void buttonExel_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (opfd.ShowDialog() == DialogResult.OK)
                label13.Text = opfd.FileName;
            string stringconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + opfd.FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(stringconn);
            if (label13.Text != "")
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Sheet1$]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                strConnection.Open();
                MySqlCommand cmd;
                cmd = strConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO data_alumni (nomor_induk,nama,tahun_keluar,alamat,telepon) VALUES (@nomor_induk,@nama,@tahun_keluar,@alamat,@telepon)";
                cmd.Parameters.AddWithValue("@nomor_induk", dataGridView2.Rows[i].Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@nama", dataGridView2.Rows[i].Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@tahun_keluar", dataGridView2.Rows[i].Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@alamat", dataGridView2.Rows[i].Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("@telepon", dataGridView2.Rows[i].Cells[4].Value.ToString());
                cmd.ExecuteNonQuery();
                loadData(nik);
                refresh();
                strConnection.Close();
            }
            refresh();
              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label14.Text == "")
            {
                label14.Text = "ok";
                strConnection.Open();
                loadData2(nik);
                refresh();
                strConnection.Close();
                button3.BackColor = Color.DimGray;
            }
            else
            {
                label14.Text = "";
                strConnection.Open();
                loadData(nik);
                refresh();
                strConnection.Close();
                button3.BackColor = Color.Gainsboro;
                
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true); 
            
        }

        private void copyAlltoClipboard()
        {
            dataGridView3.SelectAll();
            DataObject dataObj = dataGridView3.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void textBoxno_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void textBoxtelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void textBoxCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCari_Click(this, new EventArgs());
            }
        }

        private void rectangleShape1_Click_1(object sender, EventArgs e)
        {

        }
        

        
      

       
    }
}

