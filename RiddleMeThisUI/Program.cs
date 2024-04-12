using System;
using System.Threading.Channels;
using RiddleMeThisBL;
using RiddleMeThisModel;

namespace RiddleMeThisUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RiddleProcess riddleProcess = new RiddleProcess();
            Points point = new Points();
             
             
                Console.Write("RIDDLE ME THIS\nENTER YOUR NAME: ");
                string name = Console.ReadLine();

                Console.WriteLine("\n\nWELCOME "+ name.ToUpper());

                int i = 0;
                int score = 0;

            foreach (var riddles in riddleProcess.getRiddle())
            {
                if (riddles.number == 1)
                {
                    Console.Write($"\n\nFIRST RIDDLE:\n{riddles.question}\nANSWER: ");
                    string answer = Console.ReadLine();

                    bool result = riddleProcess.getAnswer(answer);

                    if (result == true)
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS CORRECT");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS WRONG");
                    }

                }
                else if (riddles.number == 2)
                {
                    Console.Write($"\n\nSECOND RIDDLE:\n{riddles.question}\nANSWER: ");
                    string answer = Console.ReadLine();

                    bool result = riddleProcess.getAnswer(answer);

                    if (result == true)
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS CORRECT");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS WRONG");
                    }
                }

                else if (riddles.number == 3)
                {
                    Console.Write($"\n\nTHIRD RIDDLE:\n{riddles.question}\nANSWER: ");
                    string answer = Console.ReadLine();

                    bool result = riddleProcess.getAnswer(answer);

                    if (result == true)
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS CORRECT");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS WRONG");
                    }
                }
            }       
                    foreach (var userScore in riddleProcess.setUserAndScore(name, score))
                    {
                             if (userScore.points.score == userScore.points.maxScore)
                             {
                                 Console.WriteLine("\n\nEXCELLENT " + userScore.userName.ToUpper() + "! YOUR SCORE IS " 
                                     + userScore.points.score + "/" + userScore.points.maxScore); break;
                                    
                             }
                             else if (userScore.points.score == 2)
                             {
                                 Console.WriteLine("\n\nGOOD JOB " + userScore.userName.ToUpper() + ", YOUR SCORE IS " 
                                     + userScore.points.score + "/" + userScore.points.maxScore); break;
                             }
                             else if (userScore.points.score <= 1)
                             {
                                 Console.WriteLine("\n\nNICE TRY " + userScore.userName.ToUpper() + ", YOUR SCORE IS " 
                                     + userScore.points.score + "/" + userScore.points.maxScore); break;
                             }
                             else
                             {
                                 Console.WriteLine("??"); 
                             }
                    }
        }
    }
}
