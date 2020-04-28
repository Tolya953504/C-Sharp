using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_LR5
{
    class Automobile : Vehicle, IParameters
    {
        public Automobile():base()
        {
            Color = null;
        }
        public Automobile(string color):base ()
        {
            Color = color; 
        }
        public string Color
        {
            get;
        }
        public int Length { get; set; }
        public int Width { get; set; }
        public double CalculateParam(int width, int lenght)             //6
        {
            double param = 2 * (width + lenght);
            return param;
        }
        public struct Driver
        {
            public string name;
            public int age;
            public Driver(int age, string name)
            {
                this.age = age;
                this.name = name;
            }
        } public Driver S;
        public enum FinesInfo : int
        {
            Add = 1,
            Minus, 
            Multiply
        } 
       // public FinesInfo S2;
        public double GetFinesStat (double numb1, double numb2, FinesInfo op)
        {
            int coefficient = 1;
            double result = 0.0;
            switch (op)
            {
                case FinesInfo.Add:
                    result = coefficient * (numb1 + numb2);
                    break;
                case FinesInfo.Minus:
                    result = coefficient * (numb1 - numb2);
                    break;
                case FinesInfo.Multiply:
                    result = coefficient * numb1 * numb2;
                    break;
            }
            return result;
        }
        public override void ShowInfo(int n)
        {
            int dist = 0;
            for (var i = 0; i < n; i++)
            {
                dist += DistPerYear[i];
            }
            Console.WriteLine($"Id of the automobile is {GenerateId}\nMass is {Mass}\nOveral distance is {dist} ");
        }
    }
}
