using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Memories
{
    public class MemoryItem
    {
        //used setter to implement (M+ and M-)
        public double Value { get; set; }

        //constructor
        public MemoryItem(double value)
        {
            Value = value;
        }


    }
}