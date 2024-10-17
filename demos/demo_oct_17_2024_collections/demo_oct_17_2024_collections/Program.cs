using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_oct_17_2024_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello! I have vowels";

            //foreach (char c in input.Except(
            //    new char[] { 
            //        'a', 'e', 'i', 'o', 'u', 
            //        'A', 'E', 'I', 'O', 'U' 
            //    }))
            string s = new string (
                input.Except(
                new char[] {
                    'a', 'e', 'i', 'o', 'u',
                    'A', 'E', 'I', 'O', 'U'
                }).ToArray());


                
            Console.WriteLine(s);

            Console.ReadKey();

            // what if:
            // I want this as a string?
            // I want this to be case insensitive?

        }
    }
}
