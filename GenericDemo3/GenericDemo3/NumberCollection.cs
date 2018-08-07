using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo3
{
    class NumberCollection : List<int>
    {

        public NumberCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(-i*3+100);
            }
        }

        public NumberCollection(IEnumerable<int> collection) : base(collection)
        {

        }

        public void Print()
        {
            foreach(int i in this)
            {
                Console.WriteLine(i);
            }
        }
    }
}
