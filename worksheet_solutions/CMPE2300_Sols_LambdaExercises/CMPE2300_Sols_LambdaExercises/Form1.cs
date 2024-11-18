using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300_Sols_LambdaExercises
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // given the following collection of value types, write the indicated lambda expressions

            List<int> lNums = new List<int>(new int[] { 1, 3, 4, 6, -1, 22, 68 });

            // show numbers

            lNums.ForEach(q => Console.Write($"{q}, "));
            Console.WriteLine("");

            // or better yet, use string.Join:

            Console.WriteLine(string.Join(",", lNums));

            // Show the list in descending order:
            Console.WriteLine(string.Join(",", lNums.OrderByDescending(q => q)));

            // make the list only the ascending sorted +ve set of numbers
            lNums = lNums.Where(q => q > 0).OrderBy (q=>q).ToList();
            Console.WriteLine(string.Join(",", lNums));

            // reset collection
            lNums = new List<int>(new int[] { 1, 3, 4, 6, -1, 22, 68 });

            // show elements until the element is less than its index
            Console.WriteLine(string.Join(",", lNums.TakeWhile((q, i) => q > i)));

            // reset collection
            lNums = new List<int>(new int[] { 1, 3, 4, 6, -1, 22, 68 });

            // show elements where the element is less than its index
            Console.WriteLine(string.Join(",", lNums.Where((q, i) => q < i)));

            // reset collection
            lNums = new List<int>(new int[] { 1, 3, 4, 6, -1, 22, 68 });

            // produce a list of doubles that are the square root of the list elements
            List<double> d = lNums.Select(q => Math.Sqrt(q)).ToList();

            // or with ctor:
            //List<double> d = new List<double>(lNums.Select(q => Math.Sqrt(q)));

            Console.WriteLine(string.Join(",", d.Select(q=>$"{q:f3}")));

            string a = "This is a test of the early warning system!";
            string v = "AEIOUaeiou";

            // produce a distinct collection of characters that are not vowels from a, using v
            // only non-whitespace characters should be shown, in ascending order, as a comma
            // separated list

            Console.WriteLine(string.Join(",", 
                a.Except(v).
                OrderBy(q => q).
                Where(q => !char.IsWhiteSpace(q))));

            // categorize the characters in the following string by count (use a dictionary)
            // order the dictionary by decreasing count, projecting it back to a dictionary
            // switching the count into an integer % of total character count
            string rod = "There is a fifth dimension beyond that which is known to man ... a dimension as vast as space and as timeless as infinity. It is the middle ground between light and shadow, between science and superstition, and it lies between the pit of man's fears and the summit of his knowledge. This is the dimension of imagination.";

            // categorize by count
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in rod)
            {
                if (!dic.ContainsKey(c))
                    dic[c] = 1;
                else
                    dic[c] += 1;
            }

            // flip to ordered %
            dic = dic.OrderByDescending(q => q.Value).
                ToDictionary(
                q => q.Key,
                q => (int)((q.Value / (float)rod.Count()) * 100));

            foreach (KeyValuePair<char, int> row in dic)
                Console.WriteLine($"{row.Key} : {row.Value}%");
        }
    }
}
