using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

//public delegate int Comparison<in T>(T x, T y);

namespace demo_oct_07_2024_comparison_lambdas
{
    public partial class Form1 : Form
    {        
        private List<int> _stuff = new List<int>();
        private Random _rnd = new Random();

        // provide the comparing function in Form1
        //  this is compliant with the above 'Comparison'
        //  delegate definition
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; ++i)
                _stuff.Add(_rnd.Next(-5, 6));

            // use my custom comparison method to perform
            //  the item-to-item comparisons
            // NOTE: Sort will still call this method
            //  as many times as necessary to complete
            //  the sort.

            // Note: this shorthand form is *still*
            //  wrapped in the appropriate delegate
            //  type, and must match the delegate
            //  form!            
            Comparison<int> blah = new Comparison<int>(utility.MyComp);
            _stuff.Sort(blah); // same as below

            _stuff.Sort(delegate (int A, int B)
            {
                return B.CompareTo(A);
            });

            _stuff.Sort((A,B) => B.CompareTo(A));

             
            //_stuff.Sort(new Comparison<int> (MyComp));

            Console.WriteLine(string.Join(", ", _stuff));
            // -4, 4, 1, -5, 4, 4, 0, 0, -3, -3
            // -5, -4, -4, -3, -1, -1, 0, 1, 3, 4
        }
    }
}