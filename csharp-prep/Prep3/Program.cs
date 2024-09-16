using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! Welcome to Guess-Magic-Number Game");
        Console.WriteLine();

        string response = "";

        do
        {

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int userGuess;
            int guessCount = 0;

            do
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;

                if (userGuess > magicNumber)
                {
                    Console.WriteLine("Guess Lower!");
                }
                else if (userGuess < magicNumber)
                {
                    Console.WriteLine("Guess Higher!");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed correctly.");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                    Console.WriteLine();
                    Console.WriteLine("Do you want to continue? (yes/no) ");
                    response = Console.ReadLine();
                }

            } while (userGuess != magicNumber);
        } while (response == "yes");
    }
}