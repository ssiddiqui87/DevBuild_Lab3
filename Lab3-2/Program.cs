using System;
using System.Collections.Generic;

namespace Lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Decarations
            Dictionary<string, double> inventory = new Dictionary<string, double>();
            List<string> menuItems = new List<string>();
            List<double> itemPrices = new List<double>();

            Console.WriteLine("Welcome to the Kwik-E-Mart!");

            //Add items to dictionary
            inventory["apple"] = 0.99;
            inventory["banana"] = 1.19;
            inventory["cherry"] = 1.59;
            inventory["dates"] = 2.39;
            inventory["elderberry"] = 4.29;
            inventory["figs"] = 3.89;
            inventory["grapes"] = 2.79;
            inventory["honeydew"] = 10.49;

            //Set flag for while loop
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine();

                //Output items from dictionary
                foreach (KeyValuePair<string, double> kvPair in inventory)
                {
                    Console.WriteLine($" {kvPair.Key,-15} {kvPair.Value,5}");
                }

                //Ask user what they would like to buy?
                Console.Write("\nWhat would you like to buy? ");

                //bool flag for input validation
                bool invalid = true;
                string input = Console.ReadLine();
                do
                {
                    //Check if user input exists in dictionary
                    if (inventory.ContainsKey(input))
                    {
                        //If it does, it will get the value and output it to a double called price
                        inventory.TryGetValue(input, out double price);

                        //Add item and price to two separate lists
                        menuItems.Add(input);
                        itemPrices.Add(price);

                        //Output item and price that was added
                        Console.WriteLine($"Adding {input} to cart. Price: ${price}.");

                        //Change flag to break out of loop
                        invalid = false;
                    }

                    //If user input does not match any key in dictionary, prompt them to re-enter and restart loop
                    else
                    {
                        Console.Write("Item does not exist. What would you like to buy? ");
                        input = Console.ReadLine();
                        continue;
                    }
                } while (invalid == true);

                //Method to set flag for while loop based on user input
                flag = RunAgainBool("\nDo you want to add another item? (enter y or n): ");
            }

            //variable to calculate average
            double sum = 0;

            //For loop to output cart and keep count of sum for average calculation
            Console.WriteLine("\nHere are the items in your cart: ");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{menuItems[i]} {itemPrices[i]}");
                sum += itemPrices[i];
            }

            //Divide the sum by count of one of the lists and round to 2 decimal places
            Console.WriteLine($"\nThe average price of items is: ${System.Math.Round((sum / itemPrices.Count), 2)}.");

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