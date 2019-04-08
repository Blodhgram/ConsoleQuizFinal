using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuiz
{
    static class Results
    {
        public static List<Question> firstResults = new List<Question>();
        public static List<Question> finalResults = new List<Question>();


        public static void AddResult(Question questionResult)
        {
            firstResults.Add(questionResult);
        }

        public static void AddFinalResult(Question question)
        {
            finalResults.Add(question);
        }

        public static void RunSecondAttempt()
        {
            Console.Clear();
            Console.WriteLine("Attempt #2:");

            for (int i = 0; i < firstResults.Count; i++)
            {
                Console.WriteLine("\n--------------------------------");
                Console.WriteLine("\nQuestion " + (1 + i).ToString());

                if(firstResults[i].isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThis one was correct!");
                    Console.ForegroundColor = ConsoleColor.White;
                    firstResults[i].PrintQuestion();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your answer: " + firstResults[i].inputAnswer);
                    Console.ForegroundColor = ConsoleColor.White;
                    AddFinalResult(firstResults[i]);
                    Console.WriteLine("Press any key to continue to the next question.");
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This one was wrong on the first attempt! Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (firstResults[i].Ask())
                    {
                        AddFinalResult(firstResults[i]);
                        Console.WriteLine("Press any key to continue to the next question.");
                    }
                    else
                    {
                        AddFinalResult(firstResults[i]);
                    }

                    Console.WriteLine("\n--------------------------------");
                }

                Console.Clear();
            }
        }
    }
}