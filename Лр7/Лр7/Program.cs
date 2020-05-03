using System;

namespace Лр7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber a = new RationalNumber(3, 7);
            RationalNumber b = new RationalNumber(5, 18);
            Console.WriteLine(a.ToString());
            Console.WriteLine(a.ToString("F"));
            Console.WriteLine(a.ToString("E"));
            Console.WriteLine((a + b).ToString());
            //------------------------------------------------------------------
            RationalNumber c = new RationalNumber();
           // string d = "12,2";
            string j = "45,06E+001";
            c = RationalNumber.Parse(j, "F");
            Console.WriteLine(c.ToString());
            //string j = "45,06E+001";
            //double t = Convert.ToDouble(j);
            //Console.WriteLine(Convert.ToString(j));
            //------------------------------------------------------------------
            RationalNumber s = new RationalNumber(10, 1);
            RationalNumber d = new RationalNumber(1, 3);
            RationalNumber f = new RationalNumber(2, 1);
            RationalNumber[] number = new RationalNumber[] { s, d, f };
            Array.Sort(number);
            foreach (RationalNumber p in number)
            {
                Console.WriteLine(p.ToString());
            }
            //-------------------------------------------------------------------
            RationalNumber h = new RationalNumber(1, 2);
            RationalNumber t = new RationalNumber(5, 9);
            Console.WriteLine(Convert.ToString(h.Equals(t)));
            //-------------------------------------------------------------------
            RationalNumber k = new RationalNumber(1, 2);
            int l = (int)k;
            double m = (double)k;
            Console.WriteLine("{0}, {1}", l, m);       
        }
    }
}
