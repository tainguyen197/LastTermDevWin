using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastTerm
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public struct Frequency
        {
            public string Path;
            public int f;
        }

        public List<Frequency> Listf = new List<Frequency>();
        public Form3()
        {
            //this.ShowInTaskbar = false;

            // this.WindowState = FormWindowState.Minimized;
            InitializeComponent();
            InitDraw();
            this.Visible = false;
        }

        void InitDraw()
        {
            Frequency line = new Frequency();
            System.IO.StreamReader file =
    new System.IO.StreamReader(@".\Frequency.txt");
            while ((line.Path = file.ReadLine()) != null)
            {
                if (Search(line.Path) == 0)
                {

                    Listf.Add(line);
                }
            }
            file.Close();

            File.WriteAllText(@".\WriteText1.txt", string.Empty);
            StreamWriter writer;
            using (writer = File.AppendText(@".\WriteText1.txt"))
            {
                foreach (var item in Listf)
                {
                    string s = item.f + " - " + item.Path;
                    writer.WriteLine(s);
                }
            }
            writer.Close();
            Draw();

        }


        int Search(string s)
        {
            Frequency item;
            if (s == "")
                return -1;

            for (int i = 0; i < Listf.Count(); i++)
            {
                item = Listf[i];
                //Tăng tần suất nếu có
                if (item.Path == s)
                {
                    item.f++;
                    Listf[i] = item;
                    return -1;
                }
            }

            return 0;
        }

        void Draw()
        {
            int j = 0;
            foreach (var item in Listf)
            {
                {
                    chart1.Series["App use"].Points.Add(item.f + 1);
                    chart1.Series["App use"].Points[j].AxisLabel = "Peter";
                    chart1.Series["App use"].Points[j].Color = Color.FromArgb(j * 5 + 30, 200 - j * 4, 255 - j * 10);
                    chart1.Series["App use"].Points[j].LegendText = item.Path.Substring(item.Path.LastIndexOf(@"\") + 1);
                    chart1.Series["App use"].Points[j].Label = (item.f + 1).ToString();
                }
                j++;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {



        }
    }
}
