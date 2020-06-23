using System;

namespace Spaceman
{
    class Game
    {
        public string CodeWord { get; private set; } // word to guess
        public string CurrentWord { get; private set; } // players guess
        public int MaxGuesses { get; }
        public int WrongGuesses { get; private set; }
        // codewords
        private string[] wordBank = new string[] {
          "galaxy",
          "gravity",
          "spacecraft",
          "aliens",
          "planets",
          "sighting",
          "stars"
        };

        private Ufo spaceship = new Ufo();

        public Game()
        {
            Random r = new Random();
            CodeWord = wordBank[r.Next(wordBank.Length)]; // Select random codeword from the array
            MaxGuesses = 5;
            WrongGuesses = 0;
            for (int i = 0; i < CodeWord.Length; i++)
            {
                CurrentWord += "_";
            }
        }

        public void Greet()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============");
            Console.WriteLine("Spaceman: The Game");
            Console.WriteLine("=============");
            Console.WriteLine("Instructions: save your friend from alien abduction by guessing the letters in the codeword.");
            Console.ResetColor();
        }

        public void Display()
        {
            PrintColorMessage(ConsoleColor.Blue, spaceship.Stringify());
            PrintColorMessage(ConsoleColor.Yellow, $"Current word: {CurrentWord}\n");
            PrintColorMessage(ConsoleColor.Yellow, ($"Incorrect guesses: {WrongGuesses}\n"));
        }

        public void Ask()
        {
            PrintColorMessage(ConsoleColor.Yellow, "Guess a letter: ");
            string stringGuess = Console.ReadLine(); // Get users input
            Console.WriteLine();

            // Check if users input is of length 1  and is a letter
            if (stringGuess.Trim().Length != 1 || int.TryParse(stringGuess.Trim(), out _))
            {
                PrintColorMessage(ConsoleColor.Red, "Only a single letters are accepted!");
                return;
            }

            // Convert user inpur string to char and add to char array
            char guess = stringGuess.Trim().ToCharArray()[0];
            if (CodeWord.Contains(guess))
            {
                // If word contains given letter, find its index ....
                PrintColorMessage(ConsoleColor.Yellow,$"'{guess}' is in the word!");
                
                for (int i = 0; i < CodeWord.Length; i++)
                {
                    if (guess == CodeWord[i])
                    {
                        //... and replace '_' in a string with a letter
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
                    }
                }
            }
            else
            {
                // If codeword doesn't contain the letter, increase number of wrong guesses...
                Console.WriteLine();
                PrintColorMessage(ConsoleColor.Yellow, $"'{guess}' isn't in the word! The tractor beam pulls the person in further...");
                WrongGuesses++;
                // Update the string representation of a spaceship according to a current number of wrong guesses
                spaceship.AddPart();
            }
        }

        public bool DidWin() => (CodeWord.Equals(CurrentWord)) ? true : false;

        public bool DidLose() => (WrongGuesses >= MaxGuesses) ? true : false;

        public void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}