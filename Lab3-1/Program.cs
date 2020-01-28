using System;

namespace Lab3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Information Lookup");

            //Create 3 arrays
            string[] names = { "Adam", "Brad", "Charlie", "Dave", "Ed", "Frank", "Gina", "Harry", "Isaac", "Jake" };
            string[] candy = { "Almond Joy", "Butterfinger", "Crunchie", "Double Bubble", "Eclair", "Fun Dip", "Ghiradelli", "Hershey", "Ice Breaker", "Jolly Rancher" };
            string[] title = { "Artist", "Business Analyst", "Coder", "Data Analyst", "Engineer", "Forklift Driver", "General Surgeon", "Hair Stylist", "Ice Cream Tester", "Jazz Musician" };

            //Declarations
            int input;
            char key;
            string userInput;

            //Ask student if they want to look up one student or display all
            Console.Write("Enter 1 to look up one student or enter 2 to display all students. ");
            input = int.Parse(Console.ReadLine());

            //If they only want to look up one student, this will run
            if (input == 1)
            {
                //While loop to run until user wants to exit
                while (true)
                {
                    //Calls method which validates input
                    input = GetInt("What user would you like to learn more about? (Enter a number 1-10): ");

                    //Output name and ask if they want to see candy or title
                    Console.Write($"This student is {names[input]}. What would you like to know about {names[input]}? (Enter \"favorite candy\" or \"previous title\") ");
                    
                    //Convert to lower case for input validation
                    userInput = Console.ReadLine().ToLower();
                    
                    //Declare flags
                    bool flag = true;
                    bool candyFlag = true;
                    
                    //Input validation which will accept "favorite candy/candy" or "previous title/title" 
                    while (flag == true)
                    {
                        if (userInput == "favorite candy" || userInput == "candy")
                        {
                            Console.WriteLine($"{names[input]}'s favorite candy is {candy[input]}.");
                            flag = false;
                        }
                        else if (userInput == "previous title" || userInput == "title")
                        {
                            Console.WriteLine($"{names[input]}'s previous title was {title[input]}.");
                            //If user selets title, candyFlag is set to false
                            candyFlag = false;
                            flag = false;
                        }
                        else
                        {
                            Console.Write("That is not a valid entry. Enter \"favorite candy\" or \"previous title\": ");
                            userInput = Console.ReadLine();
                        }
                    }

                    //Ask user if they want more info about student
                    Console.Write($"Would you like learn more about {names[input]}? (y/n): ");
                    userInput = Console.ReadLine();

                    if (userInput == "y")
                    {
                        //If candyFlag was set to false above, candy will be outputted
                        if (candyFlag == false)
                        {
                            Console.WriteLine($"{names[input]}'s favorite candy is {candy[input]}.");
                        }

                        //If candyDlay was is still true, previous title will be outputted
                        else
                        {
                            Console.WriteLine($"{names[input]}'s previous title was {title[input]}.");
                        }

                        //Ask user if they want to look up another student
                        Console.Write("Would you like learn about someone else? (y/n): ");
                        
                        //Input validation for looking up other user
                        key = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        while (key != 'y')
                        {
                            if (key == 'n')
                            {
                                return;
                            }
                            else
                            {
                                Console.Write("\nThat is not a valid entry. Enter y or n: ");
                                key = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                            }
                        }
                    }

                }
            }

            //This will run if user wants to display all students
            else if (input == 2)
            {
                for (int i = 0; i <= 9; i++)
                {
                    Console.WriteLine($"Student {i + 1}'s name is {names[i]}. {names[i]}'s favorite candy is {candy[i]}. {names[i]}'s previous title was {title[i]}.");
                }
            }
        }

        //Method to get input from user and validate to make sure it is between 1 and 10
        static int GetInt(string prompt)
        {
            Console.Write(prompt);
            int index = int.Parse(Console.ReadLine());
            bool flag = true;
            while (flag == true)
            {
                if (index > 0 && index <= 10)
                {
                    flag = false;
                }
                else
                {
                    Console.Write("That is not a valid entry. Please enter a number between 1 and 10: ");
                    index = int.Parse(Console.ReadLine());
                }
            }

            //Returns index - 1 since user is selecting index + 1
            return index - 1;
        }
    }
}
