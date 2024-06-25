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
            string user = null;

            try 
            { 
                Console.WriteLine("                                              ");
                Console.WriteLine("    _________                                 ");
                Console.WriteLine("   /  _____  \\                               ");
                Console.WriteLine("  /  /     \\  \\                             ");
                Console.WriteLine(" |  |       |  |                              ");
                Console.WriteLine("  \\  \\_____/  /                             ");
                Console.WriteLine("   \\_________/                               ");
                Console.WriteLine("   /  _____  \\                               ");
                Console.WriteLine("  RIDDLE ME THIS                              ");
                Console.WriteLine(" |A. CHOOSE USER                              ");
                Console.WriteLine("  B. NEW USER \\                              ");
                Console.WriteLine("  C. DELETE USER\\                              ");
                Console.Write("   \\_CHOOSE===: ");
                char choice = Convert.ToChar(Console.ReadLine());

                if (choice.Equals('a') || choice.Equals('A'))
                {
                    Console.WriteLine("\nUSERS:\n");

                    foreach (var users in userProcess.getUser())
                    {
                        Console.WriteLine("* " + users.userName.ToUpper() + "\n");
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
                        Main(args);
                    }
                }
                else if (choice.Equals('B') || choice.Equals('b'))
                {
                    Console.Write("\nENTER YOUR NAME: ");
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
                else if (choice.Equals('C') || choice.Equals('c'))
                {
                    Console.WriteLine("\nUSERS:\n");

                    foreach (var users in userProcess.getUser())
                    {
                        Console.WriteLine("* " + users.userName.ToUpper() + "\n");
                    }
                    Console.Write("CHOOSE USER TO REMOVE: ");
                    user = Console.ReadLine();

                    if (userProcess.verifyUser(user.ToLower()))
                    {
                        if (userProcess.DeleteUser(user.ToLower()))
                        {
                            Console.WriteLine("USER REMOVED...");
                            Main(args);
                        }
                    }
                    else
                    {
                        Console.WriteLine("WRONG INPUT OR NOT EXISTING!");
                        Main(args);
                    }
                }
                else
                {
                    Console.WriteLine("CHOOSE A LETTER, DUMDUM");
                    Main(args);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nENTER A LETTER, DUMDUM");
                Main(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR " + ex.Message);
                Main(args);
            }

                foreach (var riddles in riddleProcess.getRiddle()) //Retrieve questions
            {
                if (riddles.number == 1)
                {
                    Console.WriteLine("    _________                                 ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  /  /     \\  \\                             ");
                    Console.WriteLine(" |  |       |  |                              ");
                    Console.WriteLine("  \\  \\_____/  /                             ");
                    Console.WriteLine("   \\_________/                               ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  RIDDLE ME THIS                              ");
                    Console.WriteLine(" |FIRST RIDDLE:                              ");
                    Console.WriteLine($" |{riddles.question}\\                              ");
                    Console.Write(" \\ ANSWER===: ");
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
                    Console.WriteLine("    _________                                 ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  /  /     \\  \\                             ");
                    Console.WriteLine(" |  |       |  |                              ");
                    Console.WriteLine("  \\  \\_____/  /                             ");
                    Console.WriteLine("   \\_________/                               ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  RIDDLE ME THIS                              ");
                    Console.WriteLine(" |FIRST RIDDLE:                              ");
                    Console.WriteLine($" |{riddles.question}\\                              ");
                    Console.Write(" \\ ANSWER===: ");
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
                    Console.WriteLine("    _________                                 ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  /  /     \\  \\                             ");
                    Console.WriteLine(" |  |       |  |                              ");
                    Console.WriteLine("  \\  \\_____/  /                             ");
                    Console.WriteLine("   \\_________/                               ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  RIDDLE ME THIS                              ");
                    Console.WriteLine(" |FIRST RIDDLE:                              ");
                    Console.WriteLine($" |{riddles.question}\\                              ");
                    Console.Write(" \\ ANSWER===: ");
                    string answer = Console.ReadLine();

                    bool result = riddleProcess.getAnswer(answer);

                    if (result == true)
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS CORRECT");
                        score++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS WRONG");
                        break;
                    }
                    break;
                }
            }
            //Score
            point.score = score;
            userProcess.UpdateScore(user.ToLower(), point);
            if (Convert.ToInt32(userProcess.getScore(user).score) == 3)
            {
                Console.WriteLine("EXCELLENT " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else if (Convert.ToInt32(userProcess.getScore(user).score) == 2)
            {
                Console.WriteLine("GOOD JOB " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else if (Convert.ToInt32(userProcess.getScore(user).score) <= 1)
            {
                Console.WriteLine("NICE TRY " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else
            {
                Console.WriteLine("??");
            }
        }
        private static void ScoreCount(string user, Points point)
        {
            UserProcess userProcess = new UserProcess();
            userProcess.UpdateScore(user.ToLower(), point);
            //int currentScore = Convert.ToInt32(userProcess.getScore(user).score);
            if (Convert.ToInt32(userProcess.getScore(user).score) == 3)
            {
                Console.WriteLine("EXCELLENT " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else if (Convert.ToInt32(userProcess.getScore(user).score) == 2)
            {
                Console.WriteLine("GOOD JOB " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else if (Convert.ToInt32(userProcess.getScore(user).score) <= 1)
            {
                Console.WriteLine("NICE TRY " + user + "! YOUR SCORE IS " + userProcess.getScore(user).score + " /3");
            }
            else
            {
                Console.WriteLine("??");
            }
        }
    }
}
