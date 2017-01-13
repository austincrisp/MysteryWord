﻿using System;
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

                if (guesses > 1 && !validInput(userInput))
                {
                    Console.Write("Invalid input. ");
                    guesses--;
                }
                else if (guesses > 1 && validInput(userInput))
                {
                    blanks = FindAndReplace(word, userInput, blanks);
                    //wordList[randomNumber].Replace("_",)
                }
                else
                {
                    Console.WriteLine("DEBUG!!!! Game Over");
                    noWinner = false;
                }
                Console.WriteLine($"You have {guesses} guesses left. \n");
            }
        }

        static bool validInput(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
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
