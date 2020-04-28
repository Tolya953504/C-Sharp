using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_LR5
{
    interface IMovable
    {
        public const int minSpeed = 0;     // минимальная скорость
        public const int maxSpeed = 60;
        public double GetTime(double distance, double speed);
        public int MaxSpeed { get; }
    }
}
