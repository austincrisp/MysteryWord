using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MysteryWord
{
    class Program
    {
        static void Main(string[] args)
        {
            playGame();
        }

        static void playGame()
        {
            bool noWinner = true;
            int guesses = 8;
            string userInput = "";

            Console.WriteLine("Let's play Hangman! \n");
            Console.WriteLine("You have 8 tries to guess the word correctly. \n");

            string[] contents = File.ReadAllLines(@"..\..\words.txt");
            var wordList = contents.ToList<string>();

            var rng = new Random();
            int randomNumber = rng.Next(wordList.Count);

            Console.WriteLine("Here is your word. \n");

            string word = wordList[randomNumber];
            List<char> blanks = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                blanks.Add('_');
            }

            while (noWinner)
            {
                Console.Write(string.Join(" ", blanks));
                Console.WriteLine("\n");
                Console.Write("Choose a letter: ");
                userInput = Console.ReadLine();
                Console.WriteLine();

                if (guesses >= 1 && !validInput(userInput))
                {
                    Console.Write("Invalid input. Try again. ");
                }
                else if (guesses >= 1 && validInput(userInput))
                {
                    blanks = FindAndReplace(word, userInput, blanks);

                    if (!blanks.Contains(userInput[0]))
                    {
                        Console.Write($"{userInput} does not exist in this word. Try again. \n");
                        guesses--;
                    }
                }

                if (guesses < 1 && blanks.Contains('_'))
                {
                    Console.WriteLine(word);
                    Console.WriteLine("You failed to guess the word. You Lose! Game Over!");
                    noWinner = false;
                    break;
                }
                else if (guesses >= 1 && !blanks.Contains('_'))
                {
                    Console.WriteLine(word);
                    Console.WriteLine();
                    Console.WriteLine("CONGRATULATIONS! You guessed the word. You Win! Game Over!");
                    noWinner = false;
                    break;
                }

                Console.WriteLine($"You have {guesses} guesses left. \n");
            }
        }

        static bool validInput(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z-]+$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        static List<char> FindAndReplace(string randomWord, string input, List<char> blank)
        {
            for (int j = 0; j < randomWord.Length; j++)
            {
                if (randomWord[j] == input[0])
                {
                    blank[j] = input[0];
                }
            }

            return blank;
        }
    }
}
