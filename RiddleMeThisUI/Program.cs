using System;
using System.Drawing;
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
            UserProcess userProcess = new UserProcess();
            Points point = new Points();
            int score = 0;
            string user = Login();
           

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

            point.score = score;
            userProcess.UpdateScore(user.ToLower(), point);
            int currentScore = Convert.ToInt32(userProcess.getScore(user).score);
            if (currentScore == 3)
            {
                Console.WriteLine("EXCELLENT " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else if (currentScore == 2)
            {
                Console.WriteLine("GOOD JOB " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else if (currentScore <= 1)
            {
                Console.WriteLine("NICE TRY " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else 
            {
                Console.WriteLine("??");
            }
            //foreach (var userScore in riddleProcess.setUserAndScore(name, score))
            //{
            //         if (userScore.points.score == userScore.points.maxScore)
            //         {
            //             Console.WriteLine("\n\nEXCELLENT " + userScore.userName.ToUpper() + "! YOUR SCORE IS " 
            //                 + userScore.points.score + "/" + userScore.points.maxScore); break;

            //         }
            //         else if (userScore.points.score == 2)
            //         {
            //             Console.WriteLine("\n\nGOOD JOB " + userScore.userName.ToUpper() + ", YOUR SCORE IS " 
            //                 + userScore.points.score + "/" + userScore.points.maxScore); break;
            //         }
            //         else if (userScore.points.score <= 1)
            //         {
            //             Console.WriteLine("\n\nNICE TRY " + userScore.userName.ToUpper() + ", YOUR SCORE IS " 
            //                 + userScore.points.score + "/" + userScore.points.maxScore); break;
            //         }
            //         else
            //         {
            //             Console.WriteLine("??"); 
            //         }
            //}
        }
        private static string Login() 
        {
            RiddleProcess riddleProcess = new RiddleProcess();
            UserProcess userProcess = new UserProcess();
            Points point = new Points();
            string user = null;

            Console.Write("RIDDLE ME THIS\nA. LOAD GAME\nB. NEW GAME\nENTER LETTER: ");
            char choice = Convert.ToChar(Console.ReadLine());

            if (choice.Equals('a') || choice.Equals('A'))
            {
                foreach (var users in userProcess.getUser())
                {
                    Console.WriteLine(users.userName.ToUpper() + "\n");
                }
                Console.Write("CHOOSE YOUR USER: ");
                user = Console.ReadLine();

                if (userProcess.verifyUser(user.ToLower()))
                {
                    Console.WriteLine("CURRENT SCORE: " + userProcess.getScore(user).score);
                    point.score = userProcess.getScore(user).score;
                }
                else 
                {
                    Console.WriteLine("WRONG INPUT OR NOT EXISTING!");
                    Login();
                }
            }
            else if (choice.Equals('B') || choice.Equals('b'))
            {
                Console.Write("ENTER YOUR NAME: ");
                user = Console.ReadLine();
                if (userProcess.verifyUser(user.ToLower()) == true)
                {
                    Console.WriteLine("EXISTING USER!");
                }
                else if (userProcess.verifyUser(user.ToLower()) == false)
                {
                    userProcess.AddUserAndScore(user.ToLower(), point);
                    Console.WriteLine("WELCOME " + user.ToUpper() + "!");
                }
            }
            else 
            {
                Console.WriteLine("CHOOSE A LETTER, DUMDUM");
                Login();
            }
            return user;
        }
    }
}
