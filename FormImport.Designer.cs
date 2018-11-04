namespace WindowsFormsApplication2
{
    partial class FormImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxpathBackUp = new System.Windows.Forms.TextBox();
            this.buttonbrowseBackUp = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPathOpenFileRestore = new System.Windows.Forms.TextBox();
            this.buttonBrowseRestore = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 274);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.textBoxpathBackUp);
            this.tabPage3.Controls.Add(this.buttonbrowseBackUp);
            this.tabPage3.Controls.Add(this.buttonBackup);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(576, 248);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Backup Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Backup Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Simpan Di";
            // 
            // textBoxpathBackUp
            // 
            this.textBoxpathBackUp.Enabled = false;
            this.textBoxpathBackUp.Location = new System.Drawing.Point(122, 84);
            this.textBoxpathBackUp.Name = "textBoxpathBackUp";
            this.textBoxpathBackUp.ReadOnly = true;
            this.textBoxpathBackUp.Size = new System.Drawing.Size(286, 21);
            this.textBoxpathBackUp.TabIndex = 12;
            // 
            // buttonbrowseBackUp
            // 
            this.buttonbrowseBackUp.Location = new System.Drawing.Point(414, 84);
            this.buttonbrowseBackUp.Name = "buttonbrowseBackUp";
            this.buttonbrowseBackUp.Size = new System.Drawing.Size(75, 23);
            this.buttonbrowseBackUp.TabIndex = 11;
            this.buttonbrowseBackUp.Text = "Browse";
            this.buttonbrowseBackUp.UseVisualStyleBackColor = true;
            this.buttonbrowseBackUp.Click += new System.EventHandler(this.buttonbrowseBackUp_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(414, 129);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(115, 73);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.textBoxPathOpenFileRestore);
            this.tabPage4.Controls.Add(this.buttonBrowseRestore);
            this.tabPage4.Controls.Add(this.buttonRestore);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(576, 248);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Restore Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Restore Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Open File";
            // 
            // textBoxPathOpenFileRestore
            // 
            this.textBoxPathOpenFileRestore.Enabled = false;
            this.textBoxPathOpenFileRestore.Location = new System.Drawing.Point(115, 87);
            this.textBoxPathOpenFileRestore.Name = "textBoxPathOpenFileRestore";
            this.textBoxPathOpenFileRestore.ReadOnly = true;
            this.textBoxPathOpenFileRestore.Size = new System.Drawing.Size(286, 21);
            this.textBoxPathOpenFileRestore.TabIndex = 16;
            // 
            // buttonBrowseRestore
            // 
            this.buttonBrowseRestore.Location = new System.Drawing.Point(407, 87);
            this.buttonBrowseRestore.Name = "buttonBrowseRestore";
            this.buttonBrowseRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseRestore.TabIndex = 15;
            this.buttonBrowseRestore.Text = "Browse";
            this.buttonBrowseRestore.UseVisualStyleBackColor = true;
            this.buttonBrowseRestore.Click += new System.EventHandler(this.buttonBrowseRestore_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(407, 132);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(115, 73);
            this.buttonRestore.TabIndex = 14;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(574, 354);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormImport";
            this.Load += new System.EventHandler(this.FormImport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxpathBackUp;
        private System.Windows.Forms.Button buttonbrowseBackUp;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPathOpenFileRestore;
        private System.Windows.Forms.Button buttonBrowseRestore;
        private System.Windows.Forms.Button buttonRestore;
    }
}