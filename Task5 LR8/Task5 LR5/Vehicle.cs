using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_LR5
{
    delegate void GetMessage(int n);
    class Vehicle : IComparable, IMovable, IComparable<Vehicle>
    {
        private int relDate;
        protected int[] DistPerYear = new int[15];
        protected int dist = 0;
        public Vehicle()                    //Constructor 1 
        {
            Random rand = new Random();
            GenerateId = rand.Next(100000, 1000000);
        }
        public Vehicle(double Id)                   //For hand Id input 
        {
            GenerateId = Id;
        }
        public double GenerateId
        {
            get;
        }
        public int this[int index]                  //Indexer
        {
            get { return DistPerYear[index]; }
            set { DistPerYear[index] = value; }
        }
        public void SetDate(int Date)
        {
            relDate = Date;
        }
        public void SetDate()
        {
            relDate = 2020;
        }
        public int Mass               //Method
        {
            get; set;
        }
        public int Date
        {
            get { return relDate; }
        }
        public int CompareTo(Vehicle p)
        {
            if (this.Date == p.Date)
            {
                return 0;
            }
            else if (this.Date > p.Date)
            {
                return 1;
            }
            else return -1;
        }
        public double GetTime(double distance, double speed)
        {
            try
            {
                if(speed == 0)
                {
                    throw new DivideByZeroException("DivideByZeroException");
                }
                if(speed < 0 || distance < 0)
                {
                    throw new Exception("Negative values");
                }
                double time;
                time = distance / speed;
                return time;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public int MaxSpeed
        {
            get;set; 
        }
        public virtual void ShowInfo(int n)
        {
            int dist = 0;
            for (var i = 0; i < n; i++)
            {
                dist += DistPerYear[i];
            }
            Console.WriteLine($"Id of the vehicle is {GenerateId}\nMass is {Mass}\nOveral distance is {dist} ");
        }
        public void Consumption(int n)
        {
            int dist = 0;
            for (var i = 0; i < n; i++)
            {
                dist += DistPerYear[i];
            }
            dist /= n;
            int avSpeed = MaxSpeed / 2;
            int consumption = dist / avSpeed;
            Console.WriteLine($"Consumption of the vihicle is {consumption}");
        }
        public void Show_Message(GetMessage _del)   //Mothod using delegate
        {
            _del?.Invoke(2020 - Date);
        }
    }
}