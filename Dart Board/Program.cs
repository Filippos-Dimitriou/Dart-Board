using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dart_Board
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your score");
            int CheckScore = int.Parse(Console.ReadLine());
            List<int> Scores = new List<int>();
            if (CheckScore >= 25)
            {
                Scores.Add(25);
            }
            if (CheckScore >= 50)
            {
                Scores.Add(50);
            }
            for (int Count = 1; Count < 21; Count++)
            {
                for (int ScoreCount = 1; ScoreCount < 4; ScoreCount++)
                {
                    int TempValue = ScoreCount * Count;
                    if (Scores.Contains(TempValue) == false && TempValue <= CheckScore)
                    {
                        Scores.Add(TempValue);
                    }
                }
            }
            Scores.Sort();
            List<string> NumberCombo = new List<string>();
            for (int OuterCount = Scores.Count -1; OuterCount >= 0; OuterCount--)
            {
                int OuterNumber = Scores[OuterCount];
                if (OuterNumber % 2 == 0 && OuterNumber + 60 + 60 >= CheckScore && OuterNumber != CheckScore)
                {
                    bool CheckMax = false;
                    for (int CheckCount = 0; CheckMax == false; CheckCount++)
                    {
                        string NumbersUsed = OuterNumber.ToString();
                        int CurrentScore = CheckScore - OuterNumber;
                        int NumberFound = 0;
                        bool ScoreZero = false;
                        int InnerCount = Scores.Count - 1;
                        for (int InnerCheck = 0;ScoreZero == false; InnerCheck++)
                        {
                            if (InnerCount < 0 || NumberFound == 2)
                            {
                                CheckMax = true;
                                ScoreZero = true;
                            }
                            else
                            {
                                int InnerNumber = Scores[InnerCount];
                                /*
                                Thread.Sleep(300);
                                Console.WriteLine();
                                Console.WriteLine($"InnerNumber - {InnerNumber}");
                                Console.WriteLine($"CurrentScore - {CurrentScore}");
                                Console.WriteLine($"InnerCount - {InnerCount}");
                                Console.WriteLine();
                                Thread.Sleep(300);*/

                                if (CurrentScore - InnerNumber > 0)
                                {
                                    NumbersUsed += "," + InnerNumber;
                                    CurrentScore -= InnerNumber;
                                    NumberFound++;
                                }
                                else if (CurrentScore - InnerNumber == 0)
                                {
                                    string TempNumbersUsed = NumbersUsed + "," + InnerNumber;
                                    if (NumberCombo.Contains(TempNumbersUsed) == false)
                                    {
                                        Thread.Sleep(200);
                                        NumbersUsed += "," + InnerNumber;
                                        Console.WriteLine(NumbersUsed);
                                        NumberCombo.Add(NumbersUsed);
                                        ScoreZero = true;
                                    }
                                    else
                                    {
                                        CurrentScore = CheckScore - OuterNumber;
                                        InnerCount--;
                                    }
                                }
                                else
                                {
                                    InnerCount--;
                                }

                            }
                        }
                    }
                }
                else if (OuterNumber == CheckScore)
                {
                    Console.WriteLine(CheckScore);
                }
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
