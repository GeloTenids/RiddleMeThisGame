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

            bool validInput = false;

            while (!validInput)
            {
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

                    switch (choice)
                    {
                        case 'A':
                        case 'a':
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
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("WRONG INPUT OR NOT EXISTING!");
                            }
                            break;

                        case 'B':
                        case 'b':
                            Console.Write("\nENTER YOUR NAME: ");
                            user = Console.ReadLine();
                            if (userProcess.verifyUser(user.ToLower()))
                            {
                                Console.WriteLine("EXISTING USER!");
                            }
                            else
                            {
                                userProcess.AddUserAndScore(user.ToLower(), point);
                                Console.WriteLine("WELCOME " + user.ToUpper() + "!");
                                validInput = true;
                            }
                            break;

                        case 'C':
                        case 'c':
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
                                    validInput = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("WRONG INPUT OR NOT EXISTING!");
                            }
                            break;

                        default:
                            Console.WriteLine("\nCHOOSE A LETTER, DUMDUM");
                            break;
                    }
                }
                catch 
                {
                    Console.WriteLine("\nWRONG INPUT!");
                }
            }
        
                foreach (var riddles in riddleProcess.getRiddle()) //Retrieve questions
                {
                    
                    
                    Console.WriteLine("    _________                                 ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  /  /     \\  \\                             ");
                    Console.WriteLine(" |  |       |  |                              ");
                    Console.WriteLine("  \\  \\_____/  /                             ");
                    Console.WriteLine("   \\_________/                               ");
                    Console.WriteLine("   /  _____  \\                               ");
                    Console.WriteLine("  RIDDLE ME THIS                              ");
                    Console.WriteLine($" |RIDDLE {riddles.number}:                              ");
                    Console.WriteLine($" |{riddles.question}\\                              ");
                    Console.Write(" \\ ANSWER===: ");
                    string answer = Console.ReadLine();

                    bool result = riddleProcess.getAnswer(answer);

                    if (result)
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS CORRECT");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("\n" + answer.ToUpper() + " IS WRONG");
                    }

                    if (riddles.number == 3)
                    {
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
    }
}
