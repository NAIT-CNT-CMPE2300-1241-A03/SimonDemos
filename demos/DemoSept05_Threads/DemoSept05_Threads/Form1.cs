using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DemoSept05_Threads
{
    public partial class Form1 : Form
    {
        private Thread _TManip = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string fname = ((string[])e.Data.GetData(DataFormats.FileDrop)).First();

            Text = fname;

            try
            {
                Bitmap bm = (Bitmap)Bitmap.FromFile(fname);
                Console.WriteLine($"X:{bm.Width} Y:{bm.Height}");

                UI_PB_Image.Image = bm;

                _TManip = new Thread(new ParameterizedThreadStart (T_ManipBitmap));
                _TManip.IsBackground = true;
                
                // comments!
                _TManip.Start(new Bitmap (bm));

            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine($"DragDrop : {err.Message}");

                // nice message to user
                MessageBox.Show("You did not appear to drop an image! Please try again!");

                return;
            }

        }

        private void T_ManipBitmap (object obj)
        {
            Bitmap bm = (Bitmap)obj;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = bm.GetPixel(x, y);

                    Color n = Color.FromArgb(c.B, c.R, c.G);

                    bm.SetPixel(x, y, n);
                }
            }

            sw.Stop();

            Console.WriteLine($"That took {sw.ElapsedMilliseconds}ms");

            Invoke(new delvbm(ChangePicture), bm);

        }

        public delegate void delvbm(Bitmap bm);

        private void ChangePicture (Bitmap bm)
        {
            UI_PB_Image.Image = bm;
        }

        private static void Process(Bitmap bm)
        {
            //int iCount = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = bm.GetPixel(x, y);

                    Color n = Color.FromArgb(c.B, c.R, c.G);

                    bm.SetPixel(x, y, n);
                }
            }

            sw.Stop();

            Console.WriteLine($"That took {sw.ElapsedMilliseconds}ms");

            //Console.WriteLine ($"There are {iCount} not so bright pixels!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
