using System;
using System.Collections.Generic;

namespace Mega_Project
{
    internal static class Numbers
    {
        public const double Pi = Math.PI;
        public const double E = Math.E;

        public static List<int> Fibonachi(int n)
        {
            List<int> fibonachiSequence = new List<int>();
            int a = 0;
            int b = 1;
            fibonachiSequence.Add(a);
            fibonachiSequence.Add(b);
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                fibonachiSequence.Add(a);
            }
            return fibonachiSequence;
        }

        public static List<int> PrimeFactor(int n)
        {
            List<int> dividers = new List<int>();
            for (int a = 2; n > 1; a++)
            {
                while (n % a == 0)
                {
                    dividers.Add(a);
                    n = n / a;
                }
            }
            return dividers;
        }

        public static double CountingPi(int n)
        {
            double x = 1;
            for (double i = 1; i < n; i++)
            {
                x += ((Math.Pow(-1, i)) / (2 + (i * 2 - 1)));
            }
            var piCalculated = x * 4;
            return piCalculated;
        }

        public static double CountingE(double n)
        {
            var eCalculated = Math.Pow((1 + 1 / n), n);
            return eCalculated;
        }

        public static string CommonPrefix(string[] ss)
        {
            switch (ss.Length)
            {
                case 0:
                    return "";
                case 1:
                    return ss[0];
                default:
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

                    return ss[0]; // all strings identical up to length of ss[0];
            }


        }

        private static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }
            for (var i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

        public static List<int> PrimeNumbers(int start, int count)
        {
            var primeNumbers = new List<int>();
            var number = start;
            while (primeNumbers.Count < count)
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
                number++;
            }
            return primeNumbers;
        }

    }
}

