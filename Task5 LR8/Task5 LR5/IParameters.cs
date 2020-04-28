using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_LR5
{
    interface IParameters
    {
        int Width{get;}
        int Length { get;}
        double CalculateParam(int lenght, int wight);
    }
}
