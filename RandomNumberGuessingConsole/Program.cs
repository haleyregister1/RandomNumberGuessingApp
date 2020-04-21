using System;

namespace RandomNumberGuessingConsole
{
    class Program
    {
        static Random rng = new Random();
        static string userAnswer;
        static int answer;
        static int userGuess;
        static int numberOfTries;
        static int upperBound;

        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Welcome to the Random Number Guessing Game!");
                Console.WriteLine("Easy, Normal, or Hard mode?");
                userAnswer = Console.ReadLine().ToLower();

                GetDifficulty();

                Console.WriteLine($"Pick a number between 1 and {upperBound}!");
                Console.WriteLine($"You have {numberOfTries} lives.");

                do
                {
                    CheckUserNumber(out userGuess);

                    if (userGuess == answer)
                    { 
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hey, you got it right!");
                    }
                    else
                    {
                        if (numberOfTries > 1)
                        {
                            numberOfTries--;

                            if (userGuess > answer)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("Your guess was too high!");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Your guess was too low!");
                            }

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Guess Again!");
                            Console.WriteLine($"You have {numberOfTries} lives left.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game Over!!");
                            break;
                        }
                    }
                } while (userGuess != answer);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Play Again?");
                playAgain = PlayAgain();
            }
        }
        private static void GetDifficulty()
        {
            switch (userAnswer)
            {
                case "easy":
                    answer = rng.Next(1, 11);
                    numberOfTries = 7;
                    upperBound = 10;
                    break;
                case "normal":
                    answer = rng.Next(1, 51);
                    numberOfTries = 5;
                    upperBound = 50;
                    break;
                case "hard":
                    answer = rng.Next(1, 101);
                    numberOfTries = 3;
                    upperBound = 100;
                    break;
                default:
                    answer = rng.Next(1, 51);
                    numberOfTries = 5;
                    upperBound = 50;
                    break;
            }
        }

        private static void CheckUserNumber(out int userGuess)
        {
            while (!int.TryParse(Console.ReadLine(), out userGuess))
            {
                Console.WriteLine("Please Enter a valid number");
            }
        }

        private static bool PlayAgain()
        {
            string userAnswer = Console.ReadLine().ToLower();
            if (userAnswer == "no")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
