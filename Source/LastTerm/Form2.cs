using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastTerm
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public  string Path = "";
        public bool isClose = false;
        public Form2()
        {
            InitializeComponent();
            
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            isClose = true;
            this.Close();
        }

        private void btChoosePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Path = folderBrowserDialog1.SelectedPath;
            tbPath.Text = Path;
        }

        private void btCc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
