using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Hangsaman
{
    internal class Program
    {
        // Prints the Hangsaman figure based on the number of wrong guesses
        private static void printHangsaman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        // Prints the word with correctly guessed letters and underscores for missing letters
        // Returns the count of correctly guessed letters
        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            // Initialize counter variables
            int counter = 0;
            int rightLetters = 0;

            Console.Write("\r\n");

            // Iterate through each character in the word
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    // The letter has been guessed correctly, print it
                    Console.Write(c + " ");
                    rightLetters+= 1;
                }
                else 
                {
                    // The letter has not been guessed, print an underscore
                    Console.Write(" ");
                }
                counter += 1;
            }
            // Return the count of correctly guessed letters
            return rightLetters;
        }

        // Prints lines to represent the letters in the word
        private static void printLines(String randomWord)
        {
            Console.Write("\r");

            // Print lines for each character in the word
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Play Hangsaman!");
            Console.WriteLine("---------------");

            // Create a random object
            Random random = new Random();

            // Create a list of words for the game
            List<string> wordDictionary = new List<string> { "button", "cookie", "internship", "nick", "mushroom", "ghost" };

            // Generate a random index to select a word from the dictionary
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            // Display underscores for each letter in the word
            foreach (char c in randomWord) 
            {
                Console.Write("_ ");
            }

            // Store the length of the word to guess
            int lenghtOfWordToGuess = randomWord.Length;

            // Initialize variables to keep track of wrong guesses, guessed letters, and correct guesses
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            // Loop until the maximum number of wrong guesses is reached or the word is guessed correctly
            while (amountOfTimesWrong != 6 && currentLettersRight != lenghtOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed) 
                {
                    // Display the letters that have been guessed
                    Console.Write(letter + " ");
                }

                // Prompt the user to guess a letter
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];

                // Check if the letter has already been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\nYou have already guessed this letter.");
                    printHangsaman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Check if the letter is in the word
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i]) 
                            {  
                            right = true; 
                            }
                    }
                    // User is right - Print the hangman again without updating the drawing
                    if (right)
                    {
                        printHangsaman(amountOfTimesWrong);
                        // Add the letter to the list of guessed letters
                        currentLettersGuessed.Add(letterGuessed);

                        // Add the correct letter to the word to guess
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");

                        // Print the word with the guessed letters
                        printLines(randomWord);
                    }
                    // User is wrong
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Update the hangman drawing
                        printHangsaman(amountOfTimesWrong);
                        // Print the word with the current guessed letters
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            // Once the word is guessed or the maximum attempts have been reached, end the game and alert the user
            Console.WriteLine("\r\nGame is over! Thank you for playing.");
        }
    }
}

