using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoClassHuman_Sept_9_2024
{
    public partial class Form1 : Form
    {
        private human human_a = new human("simon");
        private human human_b = new human("simon", 5555, 68768);

        public Form1()
        {
            InitializeComponent();
        }
    }
}
