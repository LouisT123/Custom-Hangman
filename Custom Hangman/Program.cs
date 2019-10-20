using System;
using System.Collections.Generic;

namespace Custom_Hangman
{
    public class Program
    {

        public static void Main()
        {
            Console.WriteLine("Hangman by Louis Taing");
            Console.ReadLine();

            String[] Colors = { "red", "yellow", "blue", "green", "black", "white", "pink", "orange", "purple", "brown", "gray", };
            Random rand = new Random();
            String selectedWord = Colors[rand.Next(0, Colors.Length)];

            ////test 
            //Console.WriteLine(selectedWord);
            //Console.ReadLine();

            var wrongChars = new HashSet<char>();
            var remainingChars = new HashSet<char>();
            for (int i = 0; i < selectedWord.Length; i++)
            {
                remainingChars.Add(selectedWord[i]);
            }
            var correctChars = new HashSet<char>();
            int lives = 10;
            while (remainingChars.Count > 0 && lives > 0)
            {
                char guess = GetChar();

                if (remainingChars.Contains(guess))
                {
                    //guessed right
                    remainingChars.Remove(guess);
                    correctChars.Add(guess);

                    Console.WriteLine("Congrats you guessed a correct letter!");

                    WriteChars(correctChars);
                }
                else if (correctChars.Contains(guess))
                {
                    //duplicate guess
                    Console.WriteLine("You already guessed that");
                    remainingChars.Remove(guess);
                    lives--;
                    Console.WriteLine("You have " + lives + " guesses in total");

                    Console.WriteLine("Lives Left: " + lives);
                }

                else
                {
                    //guessed wrong
                    Console.WriteLine("Looks like you guessed the wrong letter");
                    //intergrate lives system here
                    lives--;
                    Console.WriteLine("You have " + lives + " guesses in total");

                    Console.WriteLine("Lives Left: " + lives);

                }
            }
            if (lives == 0)
            {
                Console.WriteLine("You lost");
                Console.WriteLine("The correct word was " + selectedWord);
            }
            else
            {
                Console.WriteLine("You Won!");
            }

            Console.ReadLine();
        }

        public static void WriteChars(IEnumerable<char> chars)
        {
            foreach (var c in chars)
            {
                Console.WriteLine(c);
            }
        }


        public static char GetChar()
        {
        Reset:
            Console.WriteLine("Guess the Color!  Enter An Letter! ");
            string input = Console.ReadLine();
            char value;
            if (char.TryParse(input, out value))
            {
                var i = 0;
                if (input.Length > 1)
                {
                    Console.WriteLine("Please Enter only a single character at a time");
                    Console.ReadLine();
                    GetChar();

                }
                return input[i];
            }
            goto Reset;

        }
    }

}

