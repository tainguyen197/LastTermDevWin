using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Reflection;
namespace LastTerm
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string PathPre;
        private static int _var = 0;
        int index = 0;
        bool flag = false;
        public struct FileList
        {
            public string Name;
            public string FullPath;
        }

        List<FileList> listoffile = new List<FileList>();

        public Form1()
        {
            InitializeComponent();
            Displaynotify();

            Install();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide();
            
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;

        private LowLevelKeyboardProc _proc;

        private IntPtr hhook = IntPtr.Zero;


        public void Install()
        {
            _proc = hookProc;
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);

        }

        public void UnHook()
        {

            UnhookWindowsHookEx(hhook);
        }

        public IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (vkCode == 91)
                {
                    _var = 1;
                }
                if (_var == 1 && vkCode == 32)
                {
                    this.Visible = !flag;
                    flag = !flag;
                    
                    _var = 0;
                }
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
            }
            else
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }

        private void Use_Notify()
        {
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        }


        protected void Displaynotify()
        {
            try
            {
                notifyIcon1.Text = "Quick Lauch 2018";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Welcome to Quick Lauch";
                notifyIcon1.BalloonTipText = "Windows + Space for more";
                notifyIcon1.ShowBalloonTip(50);
            }
            catch (Exception ex)
            {
            }
        }

        //Get app with path
        public void GetInstalledApps(string path, int indent)
        {
            try
            {
                if ((File.GetAttributes(path) & FileAttributes.ReparsePoint)
                    != FileAttributes.ReparsePoint)
                {

                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        foreach (string files in Directory.GetFiles(folder, "*.exe"))
                        {
                            FileList temp;
                            temp.Name = Path.GetFileName(files);
                            temp.FullPath = Path.GetFullPath(files);
                            listoffile.Add(temp);
                        }

                        GetInstalledApps(folder, indent + 2);
                    }
                }
            }
            catch (UnauthorizedAccessException) { }

        }

        //Get text in richTextBox for Search(s);
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox TextFindApp = (RichTextBox)sender;
            string s = TextFindApp.Text.ToString();
            if (s != "")
            {
                lstInstalled.Items.Clear();
                //lstInstalled.Items.Add(s);
                Search(s);

            }
            else
            {
                lstInstalled.Items.Clear();
                pictureBox2.Hide();
            }
            index++;
        }

        private void Search(string s)
        {
            string line;
            foreach (var item in listoffile)
            {
                line = item.Name.ToLower();
                s = s.ToLower();
                int index = line.IndexOf(s);
                if (index == 0)
                    //lstInstalled.Items.Add(s);
                    lstInstalled.Items.Add(item.Name);
            }


        }

        //Run app
        private void lstInstalled_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(PathPre);
        }

        private void lstInstalled_KeyDown(object sender, KeyEventArgs e)
        {
            string s;
            ListBox lb = (ListBox)sender;
            s = lb.Items[lb.SelectedIndex].ToString();
            ShowIcon(s);

        }


        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Use_Notify();
        }

        private void scanToBuildDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 Scan = new Form2())
            {
                //Scan.Show();
                if (Scan.ShowDialog() == DialogResult.Cancel)
                {
                    string path = Scan.Path;
                    if (path == "")
                        MessageBox.Show("Load Fail");
                    else if (path != "")
                    {
                        GetInstalledApps(path, 0);
                        MessageBox.Show("Load Successfully");
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnHook();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public string FindPathWithName(string s)
        {
            foreach (var item in listoffile)
            {
                if (s == item.Name)
                    return item.FullPath;
            }

            return null;
        }

        private void lstInstalled_Click(object sender, EventArgs e)
        {
            string s;
            ListBox lb = (ListBox)sender;
            if (lb.Items.Count == 0)
            {
                return;
            }
            s = lb.Items[lb.SelectedIndex].ToString();


            ShowIcon(s);
        }

        private void ShowIcon(string s)
        {
            string rs = FindPathWithName(s);

            if (rs != null)
            {
                pictureBox2.Show();
                Icon ico = Icon.ExtractAssociatedIcon(rs);
                pictureBox2.Image = Bitmap.FromHicon(ico.Handle);
            }
            PathPre = rs;
        }

        private void lstInstalled_KeyDown_1(object sender, KeyEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string s;

            //Run app
            if (e.KeyCode == Keys.Enter){
                UpdateFrequency();
                System.Diagnostics.Process.Start(PathPre);                
            }

            //Delete item in list
            if (e.KeyCode == Keys.Delete)
            {
                s = lb.Items[lb.SelectedIndex].ToString();
                string path = FindPathWithName(s);
                if (Delete(path) == 0)
                {
                    MessageBox.Show("Deleted");
                    lb.Items.RemoveAt(lb.SelectedIndex);
                }
                else MessageBox.Show("Error");
            }

            else
            {

                s = lb.Items[lb.SelectedIndex].ToString();
                ShowIcon(s);
            }

        }

        private int Delete(string path)
        {
            foreach (var item in listoffile)
            {
                if (item.FullPath == path)
                {
                    listoffile.Remove(item);
                    return 0;
                }

            }
            return -1;
        }

        private void lstInstalled_DoubleClick(object sender, EventArgs e)
        {
            UpdateFrequency();
            try
            {
                System.Diagnostics.Process.Start(PathPre);
            }
            catch (Exception)
            {
                
                throw;
            } 
        }

        private int UpdateFrequency()
        {
            StreamWriter writer;
            using (writer = File.AppendText(@".\Frequency.txt"))
            {
                writer.WriteLine(PathPre);
            }
            writer.Close();
            return 0;

        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                contextMenuStrip1.ShowItemToolTips = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void viewStatitisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Stati = new Form3();
            Stati.Show();
        }


    }
}
