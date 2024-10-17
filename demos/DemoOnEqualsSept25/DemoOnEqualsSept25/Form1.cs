using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoOnEqualsSept25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Random A = new Random();
            //Random B = new Random();
            //Random C = B;

            //Console.WriteLine($"A equals B : {A.Equals(B)}");
            //Console.WriteLine($"A reference equals B : {ReferenceEquals (A, B)}");

            //Console.WriteLine($"C equals B : {C.Equals(B)}");
            //Console.WriteLine($"C reference equals B : {ReferenceEquals(C, B)}");

            CThing A = new CThing(5);
            CThing B = new CThing(5);
            CThing C = new CThing(7);

            // without an implementation of Equals in our class,
            //  we should see referential equality with .Equals
            // with an implementation of Equals in our class,
            //  we will see our logical equals behaviour
            // we can *always* force referential checks with 
            //  ReferenceEquals
            Console.WriteLine($"A equals B : {A.Equals(B)}");
            Console.WriteLine($"A equals C : {A.Equals(C)}");
            Console.WriteLine($"A ref equals B : {ReferenceEquals(A, B)}");
        }
    }

    public class CThing
    {
        private int iVal;

        public CThing (int i)
        {
            iVal = i;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CThing other))
                return false;

            return iVal.Equals(other.iVal);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
