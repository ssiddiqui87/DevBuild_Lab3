using System;
using System.Collections.Generic;

namespace Lab3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("Welcome to the word reverser!");
                Console.Write("Please enter a word or words you want to reverse: ");
                //Get input from user for word
                string input = Console.ReadLine();

                //If there is multiple words typed, it will split it at the space and store in array split
                string[] splitArray = input.Split(" ");

                Console.Write("Here is the magical reversal: ");
                foreach (string word in splitArray)
                {
                    
                    Console.Write(ReverseString(word)+ " ");
                }

                flag = RunAgainBool("\nDo you want to reverse another word? (enter y or n): ");
            }
        }

        static string ReverseString(string input)
        {
            //Stack to store each character
            Stack<char> stack = new Stack<char>();

            //Convert string to char and store in array
            char[] inputArray = input.ToCharArray();

            //for loop to push each array element into stack
            for (int i = 0; i < inputArray.Length; i++)
            {
                stack.Push(inputArray[i]);
            }

            //for loop to pop chars out of stack back into array
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = stack.Pop();
            }

            //Convert char array to string
            string reversedString = new string(inputArray);
            
            //return reversed string
            return reversedString;
        }

        static bool RunAgainBool(string message)
        {
            Console.Write(message);
            //Get input from user
            char key = Console.ReadKey().KeyChar;

            //if y is entered, it will skip the loop and return true
            while (key != 'y')
            {
                //if n is entered, it will return false
                if (key == 'n')
                {
                    Console.WriteLine();
                    return false;
                }
                //if y or n is not entered, it will prompt the user to enter again
                else
                {
                    Console.Write("\nThat is an invalid entry. Please enter y or n: ");
                    key = Console.ReadKey().KeyChar;
                }
            }
            Console.WriteLine();
            return true;
        }
    }
}
