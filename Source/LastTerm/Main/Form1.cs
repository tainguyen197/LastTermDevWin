using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hook;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;

            ListBox listBox1 = new ListBox();
            listBox1.Location = new Point(10, 10);
            listBox1.Size = new Size(200, 200);

            this.Controls.Add(listBox1);

            Hook1 _keyboardHook = new Hook1();
            _keyboardHook.Install();

            _keyboardHook.KeyDown += (sender, e) =>
            {
                listBox1.Items.Add("KeyDown: " + e.KeyCode);

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            };

            _keyboardHook.KeyUp += (sender, e) =>
            {
                listBox1.Items.Add("KeyUp: " + e.KeyCode);

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            };
        }
    }
}
 