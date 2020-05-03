using System;
using System.Collections.Generic;
using System.Text;

namespace Лр7
{
    class RationalNumber : IComparable, IEquatable<RationalNumber>, IComparable<RationalNumber>
    {
        private readonly int numerator;
        private readonly uint denominator;
        public RationalNumber()  // constructor
        {
        }
        public RationalNumber(int n, uint d)  // constructor
        {
            numerator = n;
            denominator = d;
        }
        public bool Equals(RationalNumber other)
        {
            if (other == null) return false;
            int nod = NOD(numerator, (int)denominator);
            int otherNod = NOD(other.numerator, (int)other.denominator);
            int numeratorTmp = numerator;
            numeratorTmp /= nod;
            uint denominatorTmp = denominator;
            denominatorTmp /= (uint)nod;
            int otherNumerator = other.numerator;
            otherNumerator /= otherNod;
            uint otherDenominator = other.denominator;
            otherDenominator /= (uint)otherNod;
            return (numeratorTmp == otherNumerator && denominatorTmp == otherDenominator);
        }
        public int  GetNumerator
        {
            get
            {
                return numerator;
            }
        }
        public uint GetDenominator
        {
            get
            {
                return denominator;
            }
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;

            RationalNumber number = obj as RationalNumber;
            if (number == null) 
                return false;
            else 
                return Equals(number);
        }
        public override int GetHashCode()
        {
            return Tuple.Create(numerator, (int)denominator).GetHashCode();  //Tuple, который отражает порядок каждого поля.
        }
        public int CompareTo(RationalNumber p)
        {
            double fullNumerator1 = (double)this.numerator * (double)p.denominator;
            double fullNumerator2 = (double)p.numerator * (double)this.denominator;
            if (p != null)
                return fullNumerator1.CompareTo(fullNumerator2);
            else 
                throw new Exception("Невозможно сравнить два объекта");
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public static explicit operator int(RationalNumber number)        //Conversion
        {
            return (int)(number.numerator / number.denominator);
        }
        public static explicit operator double(RationalNumber number)        //Conversion
        {
            return (double)number.numerator / (double)number.denominator;
        }
        public static explicit operator float(RationalNumber number)        //Conversion
        {
            return (float)number.numerator / (float)number.denominator;
        }
        public override string ToString()     
        {
            return ToString("G");
        }
        public string ToString(string fmt)
        {
            if (string.IsNullOrEmpty(fmt))
                fmt = "G";

            switch (fmt.ToUpperInvariant())
            {
                case "G": return numerator.ToString() + "/" + denominator.ToString();

                case "F": 
                {   
                    double k = ((double)numerator / (double)denominator);
                    return k.ToString("F");
                }
                case "E":
                {
                    double k = ((double)numerator / (double)denominator);
                    return k.ToString("E");
                }
                default:
                    string msg = string.Format("'{0}' is an invalid format string", fmt);
                    throw new ArgumentException(msg);
            }
        }
        public static RationalNumber Parse(string number, string fmt)
        {
            double a = Convert.ToDouble(number);
            int b = (int)a;
            uint denominatorTmp = 1;
            int numeratorTmp = 0;

            while ((a - (double)b) != 0)
            {
                a *= 10;
                b = (int)a;
                denominatorTmp *= 10;
            }
            int nod = NOD((int)a, (int)denominatorTmp);
            numeratorTmp = (int)(a / nod);
            denominatorTmp = (uint)(denominatorTmp / nod);
            return new RationalNumber(numeratorTmp, denominatorTmp);
        }
        private  static int NOD(int a, int b)
        {
            int r;
            if (a < b) { r = a; a = b; b = r; }
            while ((a % b) > 0) {r = a % b; a = b; b = r; }
            return b;
        }
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.numerator * b.numerator, a.denominator * b.denominator);
        }
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber((int)(a.numerator * b.denominator),(uint)(a.denominator * b.numerator));
        }
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            int f = NOD((int)a.denominator, (int)b.denominator);
            int g = ((int)b.denominator / f * a.numerator) + ((int)a.denominator / f * b.numerator);
            int h = (int)a.denominator / f * (int)b.denominator;
            f = NOD(g, h);
            g /= f;
            h /= f;
            return new RationalNumber(g,(uint)h);
        }
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            int f = NOD((int)a.denominator, (int)b.denominator);
            int g = ((int)b.denominator / f * a.numerator) - ((int)a.denominator / f * b.numerator);
            int h = (int)a.denominator / f * (int)b.denominator;
            f = NOD(g, h);
            g /= f;
            h /= f;
            return new RationalNumber(g, (uint)h);
        }
        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            int f = NOD((int)a.denominator, (int)b.denominator);
            int a1 = ((int)b.denominator / f * a.numerator);
            int b1 = ((int)a.denominator / f * b.numerator);
            return (a1 > b1);
        }
        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            int f = NOD((int)a.denominator, (int)b.denominator);
            int a1 = ((int)b.denominator / f * a.numerator);
            int b1 = ((int)a.denominator / f * b.numerator);
            return (a1 < b1);
        }
        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            int f = NOD((int)a.denominator, (int)b.denominator);
            int a1 = ((int)b.denominator / f * a.numerator);
            int b1 = ((int)a.denominator / f * b.numerator);
            return (a1 >= b1);
        }
        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            int f = NOD((int)a.denominator, (int)b.denominator);
            int a1 = ((int)b.denominator / f * a.numerator);
            int b1 = ((int)a.denominator / f * b.numerator);
            return (a1 <= b1);
        }
    }
}
