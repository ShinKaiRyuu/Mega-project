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

        public static List<int> PrimeFactor(int n)
        {
            List<int> dividers = new List<int>();
            for (int a = 2; n > 1; a++)
            {
                while (n % a == 0)
                {
                    dividers.Add(a);
                    n= n / a;
                }
            }
            return dividers;
        }

        public static double CountingPi(int n)
        {
            double x = 1;
            for (double i=1; i < n; i++)
            {
               x += ((Math.Pow(- 1, i))/(2+(i*2-1)));
            }
            double Pi = x * 4;
            return Pi;
        }

        public static double CountingE(double n)
        {
            double ee ;
            ee = Math.Pow((1 + 1 / n), n);
            return ee;
        }

        public static string CommonPrefix(string[] ss)
        {
            if (ss.Length == 0)
            {
                return "";
            }

            if (ss.Length == 1)
            {
                return ss[0];
            }

            int prefixLength = 0;

            foreach (char c in ss[0])
            {
                foreach (string s in ss)
                {
                    if (s.Length <= prefixLength || s[prefixLength] != c)
                    {
                        return ss[0].Substring(0, prefixLength);
                    }
                }
                prefixLength++;
            }

            return ss[0]; // all strings identical up to length of ss[0]
        }

        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

        public static List<int> 
    }

}
