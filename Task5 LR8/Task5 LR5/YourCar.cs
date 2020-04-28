using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_LR5
{
    class YourCar : Automobile
    {
        public event GetMessage Notify;             //Event
        public YourCar():base()                    //default Constructor
        {
            Model = "Lada";      
        }
        public YourCar(string model) : base()      //Constuctor
        {
            Model = model;
        }
        public string Model
        {
            get; set;
        }
        public double GetFinesStat(double numb1, double numb2, FinesInfo op, int dist)
        {
            try
            {
                if (numb1 < 0 || numb2 < 0 || dist < 0)
                {
                    throw new Exception("Negative values");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception has appeared: {ex.Message}");
            }
            double coefficient;
            if (dist < 5000)
            {
                coefficient = 0.5;
            }
            else if (dist < 30000)
            {
                coefficient = 1;
            }
            else
            {
                coefficient = 1.5;
            }
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
            Console.WriteLine($"Car model is {Model}\nId is {GenerateId}\nMass is {Mass}\nOveral distance is {dist} ");
            Notify?.Invoke(2020 - Date);
        }
    }
}
