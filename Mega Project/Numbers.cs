using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega_Project
{
    class Numbers
    {
        public const double Pi = Math.PI;
        public const double e = Math.E;

        public static List<int> Fibonachi(int n)
        {
            List<int> fibonachi_sequence = new List<int>();
            int a = 0;
            int b = 1;
            fibonachi_sequence.Add(a);
            fibonachi_sequence.Add(b);
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                fibonachi_sequence.Add(a);
            }
            return fibonachi_sequence;
        }
    }

}
