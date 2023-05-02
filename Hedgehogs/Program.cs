using System;
using System.Linq;
namespace Hedgehogs
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] HedgehogPopulation = { 0, 0, 0 };
            Console.WriteLine("how many red hedgehog?");
            HedgehogPopulation[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("how many grean hedgehog?");
            HedgehogPopulation[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("how many blue hedgehog?");
            HedgehogPopulation[2] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n\n\n");

            Console.WriteLine("chuse color: red = 0; grean = 1; blue = 2");
            int color = Convert.ToInt32(Console.ReadLine());

            int ansver = HedgehogMinStep.HedgehogStepCoutn(HedgehogPopulation, color);

            Console.WriteLine("\n\n");

            Console.WriteLine(ansver);
            Console.ReadLine();

        }

        class HedgehogMinStep
        {
            public static int HedgehogStepCoutn(int[] HedgehogPopulation, int color)
            {
                //checking if able to meeting
                if (NegativOrTowZero(HedgehogPopulation))
                {
                    return -1;
                }



                int step = 0;
                while (true)
                {
                    //checking if population done
                    int chek = TowEqualOrDone(HedgehogPopulation, color);

                    if (chek >= 0)
                    {
                        return step + chek;
                    }


                    // 0 , 1 , x problem check
                    if (HedgehogPopulation.Min() == 0)
                    {
                        if (HedgehogPopulation.Contains(1) && HedgehogPopulation[color] != 1)
                        {
                            return -1;
                        }

                        HedgehogMeeting(HedgehogPopulation, Array.IndexOf(HedgehogPopulation, 0));
                    }

                    HedgehogMeeting(HedgehogPopulation, color);
                    step++;
                }
            }


            /// <summary>
            /// checks if the array contains a negative number or the population is already all the same color
            /// </summary>
            /// <param name="HedgehogPopulation"></param>
            /// <returns></returns>
            private static bool NegativOrTowZero(int[] HedgehogPopulation)
            {
                bool zero = false;
                foreach (var item in HedgehogPopulation)
                {
                    if (item < 0)
                    {
                        return true;
                    }
                    if (item == 0)
                    {
                        if (zero = true)
                        {
                            return true;
                        }
                        zero = true;
                    }
                }
                return false;
            }


            /// <summary>
            /// checks if the population is already the same color of have two equal color
            /// </summary>
            /// <param name="HedgehogPopulation"></param>
            /// <returns></returns>
            private static int TowEqualOrDone(int[] HedgehogPopulation, int color)
            {
                if (HedgehogPopulation[0] == HedgehogPopulation[1] && HedgehogPopulation[0] != HedgehogPopulation[color])
                {
                    return HedgehogPopulation[0];
                }
                if (HedgehogPopulation[1] == HedgehogPopulation[2] && HedgehogPopulation[1] != HedgehogPopulation[color])
                {
                    return HedgehogPopulation[1];
                }
                if (HedgehogPopulation[0] == HedgehogPopulation[2] && HedgehogPopulation[0] != HedgehogPopulation[color])
                {
                    return HedgehogPopulation[0];
                }
                return -1;
            }


            /// <summary>
            /// Hedgehog do meeting 
            /// </summary>
            /// <param name="HedgehogPopulation"></param>
            /// <param name="color"></param>
            private static void HedgehogMeeting(int[] HedgehogPopulation, int color)
            {
                switch (color)
                {
                    case 0:
                        HedgehogPopulation[0] += 2;
                        HedgehogPopulation[1] -= 1;
                        HedgehogPopulation[2] -= 1;
                        break;

                    case 1:
                        HedgehogPopulation[0] -= 1;
                        HedgehogPopulation[1] += 2;
                        HedgehogPopulation[2] -= 1;
                        break;

                    case 2:
                        HedgehogPopulation[0] -= 1;
                        HedgehogPopulation[1] -= 1;
                        HedgehogPopulation[2] += 2;
                        break;
                }
            }
        }
    }


}
