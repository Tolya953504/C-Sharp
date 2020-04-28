using System;

namespace Task5_LR5
{
  //  delegate void GetMessage(int n);

    class Program
    {
      //  event GetMessage Notify;
        static void Main()
        {
            Console.Write("Number of vehicles to registr: ");
            int Numb = Convert.ToInt32(Console.ReadLine());
            int tmp = 0;
            Vehicle[] vehicle1 = new Vehicle[Numb];
            YourCar[] automobile1 = new YourCar[Numb];
            do
            {
                automobile1[tmp] = new YourCar("Volkswagen");
                automobile1[tmp].S.age = 32;
                automobile1[tmp].S.name = "Mike";
                Console.WriteLine("Enter mass of your vehicle in kilo:");
                int mass = Convert.ToInt32(Console.ReadLine());
                automobile1[tmp].Mass = mass;                                                //Method
                Console.WriteLine("Release date:");
                int Date = Convert.ToInt32(Console.ReadLine());
                if (Date == 2020)
                {
                    automobile1[tmp].SetDate();                                                //Method overload
                }
                else
                {
                    automobile1[tmp].SetDate(Date);                 
                    for (var i = 0; i < 2020 - automobile1[tmp].Date; i++)
                    {
                        Console.Write("Mileage for " + (i + 1) + " year: ");
                        int x;
                        string input = Console.ReadLine();
                        if (Int32.TryParse(input, out x))
                        {
                            automobile1[tmp][i] = x;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }                
                  //  automobile1[tmp].ShowInfo(2020 - automobile1[tmp].Date);
                }
               // double overalFee = automobile1[tmp].GetFinesStat(120, 123.3, Automobile.FinesInfo.Add, 2);
                tmp++;
            } while (tmp < Numb);
            Array.Sort(automobile1);
            for (int i = 0; i < Numb; i++)
            {
                Console.WriteLine(Convert.ToInt32(automobile1[i].Date));
            }
//                                                            8 LAB
//----------------------------------------------------------------------------------------------------------------------------------------------------
            try
            {
                vehicle1[0] = new Vehicle();
                double t = vehicle1[0].GetTime(100, 0);                           //Look Vehicle
                Console.WriteLine(Convert.ToString(t));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception has appeared: {ex.Message}");
            }
//----------------------------------------------------------------------------------------------------------------------------------------------------
            automobile1[tmp-1].Show_Message(automobile1[tmp-1].ShowInfo); //Calling method with delegate(Look Vehicle)
            automobile1[tmp-1].MaxSpeed = 200;
            automobile1[tmp - 1].Show_Message(automobile1[tmp - 1].Consumption); //Calling method with delegate(Look Vehicle)
            Console.WriteLine();
//----------------------------------------------------------------------------------------------------------------------------------------------------
            foreach(var i in automobile1)
            {
                i.Notify += delegate                                //anonymus method(Look YourCar)
                {
                    if (i.Date > 2010)
                    {
                        Console.WriteLine("Automobile is suitable");
                    }
                    else
                    {
                        Console.WriteLine("Automobile isn't suitable");
                        i.Notify += n => Console.WriteLine("It's too old");
                    }
                };
            }
            try
            {
                automobile1[tmp - 1].Notify += n => Console.WriteLine("It's too old");
                automobile1[tmp - 2].ShowInfo(2020 - automobile1[tmp - 2].Date);       // Testing of the event using anonymus method
                automobile1[tmp - 1].ShowInfo(2020 - automobile1[tmp - 1].Date);
                //  automobile1[tmp - 1].Notify += n => Console.WriteLine("");
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
//----------------------------------------------------------------------------------------------------------------------------------------------------
        }
    }
}