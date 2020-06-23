using System;
using System.Linq;

namespace NumberGuesser
{
    class NumberGuesser
    {
        public static void Game()
        {
            GetAppInfo();
            GreetUser();

            int min = 1;
            int max = 10;
            int guessLimit = 3;
            // Set Min & Max numbers and limit of guesses
            SetValues(out min, out max, out guessLimit); 
            
            // Start a game loop
            while (true)
            {
                Random random = new Random();
                int correctNumber = random.Next(min, max + 1);

                int guess = 0;
                int guessCount = 0;
                
                bool outOfGuesses = false;
                int[] guessesArr = new int[guessLimit]; // array of incorrect guesses

                PrintColorMessage(ConsoleColor.DarkCyan, $"Guess a number between {min} and {max}\n");

                // While guess is not correct
                while (guess != correctNumber && !outOfGuesses)
                {
                    if (guessCount < guessLimit)
                    {
                        string input = Console.ReadLine();

                        // Parse input to check if it's a number
                        if (!int.TryParse(input, out guess))
                        {
                            PrintColorMessage(ConsoleColor.Red, "Please use an actual number\n");
                            continue;
                        }

                        // Cast users input to int and put in guess variable
                        guess = Int32.Parse(input.Trim());

                        if (guess != correctNumber)
                        {
                            // If guess is out of range
                            if (guess < min || guess > max)
                            {
                                PrintColorMessage(ConsoleColor.Yellow, $"\nNumber must be in range {min} - {max}");
                            }
                            else if ((guessesArr.Contains(guess)))
                            {
                                PrintColorMessage(ConsoleColor.Yellow, $"\nYou already tried {guess}");
                            }
                            else
                            {
                                guessesArr[guessCount] = guess;
                                guessCount++;
                                PrintColorMessage(ConsoleColor.Red, $"\nWrong number, guesses left: {guessLimit - guessCount}");
                            }
                        }
                    }
                    else
                    {
                        outOfGuesses = true;
                    }
                }

                if (outOfGuesses)
                {
                    PrintColorMessage(ConsoleColor.Red, $"\nGAME OVER!! The correct number was {correctNumber}!\n");
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Green, $"\nYOU WIN!! {correctNumber} is the correct number !\n");
                }

                // Ask to start a new game
                PrintColorMessage(ConsoleColor.DarkCyan, "Play Again? [Y or N]\n");

                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    SetValues(out min, out max, out guessLimit);
                    continue;
                }
                else if (answer == "N")
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        public static void GetAppInfo()
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n{appName}\nVersion {appVersion}.\n");
            Console.ResetColor();
        }

        private static void GreetUser()
        {
            PrintColorMessage(ConsoleColor.DarkCyan, "What is your name?");
            string inputName = Console.ReadLine();
            string name = String.IsNullOrEmpty(inputName) ? "guest" : inputName;
            PrintColorMessage(ConsoleColor.DarkCyan, $"\nHello {name.ToUpper()}.\nLet's play a 'Number Guesser' game...\n");
        }

        
        private static void SetValues(out int min, out int max, out int guessLimit)
        {  
            string minVal;
            string maxVal;
            string limit;
            do
            {
                PrintColorMessage(ConsoleColor.DarkYellow, "\nSet Correct Min Value  > 0 :");
                minVal = Console.ReadLine();
            }
            while (!int.TryParse(minVal, out min) || Int32.Parse(minVal) <= 0);
           
            min = Int32.Parse(minVal);

            do
            {
                PrintColorMessage(ConsoleColor.DarkYellow, "\nSet Correct Max Value  > min :");
                maxVal = Console.ReadLine();
            }
            while (!int.TryParse(maxVal, out max) || Int32.Parse(maxVal) <= 0 || min >= Int32.Parse(maxVal));
           
            max = Int32.Parse(maxVal);

            do
            {
                PrintColorMessage(ConsoleColor.DarkYellow, "\nSet The Guess Limit  1 - 5:");
                limit = Console.ReadLine();
            }
            while (!int.TryParse(limit, out guessLimit) || Int32.Parse(limit) < 1 || Int32.Parse(limit) > 5);
            
            guessLimit = Int32.Parse(limit);
        }


        private static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color; // Change text color
            Console.WriteLine(message);
            Console.ResetColor(); // Reset text color
        }
    }
}
