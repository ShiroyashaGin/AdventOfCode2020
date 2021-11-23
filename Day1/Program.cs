using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Day1
{
    internal class Program
    {
        static int targetResult = 2020;
        static List<string> correctResults = new List<string>();
        static int visualizeDelayMs = 10;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Visualize delay in ms: ");
            int.TryParse(Console.ReadLine(), out visualizeDelayMs);
            Console.WriteLine("Advent of Code 2020 Day 1");
            Console.ResetColor();
            StreamReader reader = new StreamReader("../../../input.txt");
            string[] numbers = reader.ReadToEnd().Split("\n");
            for (int i = 0; i < numbers.Length; i++)
            {
                int loopNumber = int.Parse(numbers[i].Trim());
                Console.WriteLine(loopNumber);
                for (int o = i; o < numbers.Length; o++)
                {
                    int childNumber = int.Parse(numbers[o].Trim());
                    if(loopNumber + childNumber == targetResult)
                        Hit(loopNumber, childNumber);

                    for(int p = i; p < numbers.Length; p++)
                    {
                        int childchildNumber = int.Parse(numbers[p]);
                        if (loopNumber + childNumber + childchildNumber == targetResult)
                            Hit(loopNumber, childNumber, childchildNumber);
                    }
                }
                
                Console.ResetColor();
                Thread.Sleep(visualizeDelayMs);
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            correctResults.ForEach(x=>Console.WriteLine(x));
            Console.ResetColor();
            Console.ReadLine();
        }

        static void Hit(int numberOne, int numberTwo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string result = string.Format("{0} + {1} = {2} => {0} * {1} = {3}",numberOne,numberTwo,targetResult,numberOne*numberTwo);
            Console.WriteLine(result);
            correctResults.Add(result);
        }
        static void Hit(int numberOne, int numberTwo, int numberThree) {
            Console.ForegroundColor = ConsoleColor.Green;
            string result = string.Format("{0} + {1} + {4} = {2} => {0} * {1} * {4} = {3}", numberOne, numberTwo, targetResult, numberOne * numberTwo * numberThree,numberThree);
            Console.WriteLine(result);
            correctResults.Add(result);
        }
    }
}
