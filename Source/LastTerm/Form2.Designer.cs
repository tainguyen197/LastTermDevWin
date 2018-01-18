namespace LastTerm
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tbPath = new MetroFramework.Controls.MetroTextBox();
            this.btChoosePath = new MetroFramework.Controls.MetroButton();
            this.OK = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 71);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Choose Path";
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(133, 71);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(143, 23);
            this.tbPath.TabIndex = 3;
            // 
            // btChoosePath
            // 
            this.btChoosePath.Location = new System.Drawing.Point(282, 71);
            this.btChoosePath.Name = "btChoosePath";
            this.btChoosePath.Size = new System.Drawing.Size(22, 23);
            this.btChoosePath.TabIndex = 4;
            this.btChoosePath.Text = "...";
            this.btChoosePath.Click += new System.EventHandler(this.btChoosePath_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(133, 120);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 6;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 166);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.btChoosePath);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.metroLabel1);
            this.ForeColor = System.Drawing.Color.Purple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Scan Database";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox tbPath;
        private MetroFramework.Controls.MetroButton btChoosePath;
        private MetroFramework.Controls.MetroButton OK;


    }
}