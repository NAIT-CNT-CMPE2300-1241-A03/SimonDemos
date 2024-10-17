using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClassHuman_Sept_9_2024
{
    //internal class human
    public class human
    {
        // full name
        private string _name = "Unknown Human";

        // age in ms since Jan 01 0000
        private ulong _age;

        // height in mm
        private uint _height; 

        public human (string name)
        {
            if (name.Length < 1)
                throw new ArgumentException("Name can't have a zero length!");

            _name = name;

            _age = 0;

            _height = 0;
        }

        public human (
            string name,
            ulong age,
            
            uint height = (uint)((5 * 12 + 10) * 25.4))
            
            : this (name)
        {
            _age = age;
            _height = height;
        }
    }
}
