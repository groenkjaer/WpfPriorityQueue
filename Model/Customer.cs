using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPriorityQueue
{
    public class Customer
    {
        public enum Values
        {
            Normal = 1,
            Good = 2
        }

        private string name;
        private int customerValue;

        public int CustomerValue
        {
            get { return customerValue; }
        }

        public Customer(string _name, int _value)
        {
            name = _name;
            customerValue = _value;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
