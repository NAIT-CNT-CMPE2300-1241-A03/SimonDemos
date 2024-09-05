using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSept05_Threads
{
    public partial class Form1 : Form
    {
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

                Process(bm);
            }
            catch (Exception err)
            {
                System.Diagnostics.Trace.WriteLine($"DragDrop : {err.Message}");

                // nice message to user
                MessageBox.Show("You did not appear to drop an image! Please try again!");

                return;
            }

        }

        private static void Process(Bitmap bm)
        {
            int iCount = 0;
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = bm.GetPixel(x, y);
                                        
                    if (c.R+c.G+c.B < 128)
                    {
                        iCount++;
                    }
                }
            }

            Console.WriteLine ($"There are {iCount} not so bright pixels!");
        }
    }
}
