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

            // altered after push (make 50, in the range of 0 to 10 inclusive)
            for (int i = 0; i < 50; ++i)
                _stuff.Add(_rnd.Next(0, 11));

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
            Console.WriteLine(string.Join(", ", _stuff));

            _stuff.Sort(delegate (int A, int B)
            {
                return B.CompareTo(A);
            });
            Console.WriteLine(string.Join(", ", _stuff));

            _stuff.Sort((A,B) => B.CompareTo(A));
            Console.WriteLine(string.Join(", ", _stuff));

            //_stuff.Sort(new Comparison<int> (MyComp));

            // punt all values greater than 5::
            
            // option a:: filter!
            _stuff = _stuff.Where((q) => q <= 5).ToList();
            
            // option b:: use a direct list method
            Console.WriteLine ($"I removed {_stuff.RemoveAll((q) => q > 5)} elements!");

            // option c::
            _stuff = _stuff.FindAll((q) => q <= 5);

            Console.WriteLine(string.Join(", ", _stuff));
        }
    }
}