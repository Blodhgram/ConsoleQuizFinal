using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroGreeting();

            List<Question> question = new List<Question> {
                
                new Question("What is 1 + 1 ?", new string[] { "1", "2", "3", "4" }, Question.multipleChoice, 1),
                new Question("7 + 7 does not equal 14.", new string[] { "true", "false" }, Question.trueAndFalse, 1),
                new Question("What is 7 + 3 ?", new string[] { "1", "2", "3", "10" }, Question.multipleChoice, 3),
                new Question("Dr.Shan is AWESOME!!!", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("What is 5 x 5 ?", new string[] { "9", "2", "25", "4" }, Question.multipleChoice, 2),
                new Question("We all attend SAU", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("What is 5 x 8 ?", new string[] { "40", "45", "13", "4" }, Question.multipleChoice, 0),
                new Question("Grass is green.", new string[] { "true", "false" }, Question.trueAndFalse, 0),
                new Question("What is 2 x 5 ?", new string[] { "20", "10", "30", "40" }, Question.multipleChoice, 1),
                new Question("Programming is fun.", new string[] { "true", "false" }, Question.trueAndFalse, 0),
            };

            
            for(int i = 0; i < question.Count; i++)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Question #" + (1 + i).ToString());
                if (question[i].Ask())
                {
                    Results.AddResult(question[i]);
                    Console.WriteLine("Press any key to continue to the next question.");
                
                }
                else
                {
                    Results.AddResult(question[i]);
                }
                Console.Clear();
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("End of the first attempt.");
            int tempScore = 0;

            for(int i = 0; i < Results.firstResults.Count; i++)
            {
                if(Results.firstResults[i].isCorrect)
                {
                    tempScore++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your current mark is: " + tempScore + "/" + Results.firstResults.Count.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Results.RunSecondAttempt();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("End of the Quiz!");

            int tempFinalScore = 0;

            for (int i = 0; i < Results.finalResults.Count; i++)
            {
                if (Results.finalResults[i].isCorrect)
                {
                    tempFinalScore++;
                }
            }

            Console.WriteLine("Your final mark is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(tempFinalScore + "/" + Results.finalResults.Count.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            if (tempFinalScore > 5)
            {
                Console.WriteLine("Good Job!");
            }
            else
            {
                Console.WriteLine("Better luck next time...");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Press any key to exit the console...");
            Console.ReadKey();
        }


        public static void IntroGreeting()
        {
            
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to the Console Quiz!");
            Console.WriteLine("You will be presented with 10 questions.");
            Console.WriteLine("After your first attempt, you will be given a second try.");
            Console.WriteLine("You will only have to re-answer the questions you answered wrong.");
            Console.WriteLine("Are you ready?");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Press any key to start the quiz...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

    }
}