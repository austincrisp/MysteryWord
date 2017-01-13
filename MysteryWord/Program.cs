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

            Console.WriteLine("Let's play Hangman! \n");
            Console.WriteLine("You have 8 tries to guess the word correctly. \n");

            string[] contents = File.ReadAllLines(@"..\..\words.txt");
            var wordList = contents.ToList<string>();

            var rng = new Random();
            int randomNumber = rng.Next(wordList.Count);

            Console.WriteLine("Here is your word. \n");

            foreach (char letter in wordList[randomNumber])
            {
                Console.Write("_" + " ");
            }

            Console.WriteLine("\n");

            while (noWinner)
            {
                if (guesses > 0 && !validInput())
                {
                    guesses--;
                    Console.WriteLine($"You have {guesses} guesses left. \n");
                }
                else if (guesses > 0 && validInput())
                {
                    
                    //wordList[randomNumber].Replace("_",)
                }
                else
                {
                    noWinner = false;
                }
            }

            //Console.WriteLine(wordList[randomNumber]);
        }

        static bool validInput(List<string> randomWord)
        {
            string userInput = "";

            Console.Write("Choose a letter: ");
            userInput = Console.ReadLine();

            if (!Regex.IsMatch(userInput, @"^[a-zA-Z]+$"))
            {
                Console.Write("Invalid input. ");
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
        static List<string> FindAndReplace(List<string> randomWord, string find, string replace)
        {

        }
        */
    }
}
