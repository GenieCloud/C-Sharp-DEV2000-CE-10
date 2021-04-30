using System;
using System.Collections.Generic;

namespace Jones_James_CE10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * James M. Jones
             * 05/02/2021
             * DEV2000-O 02: Introduction to Development II
             * 4.2 Code Exercise 10: Final Project
             */

            //First thing first, greet the user and explain the program.
            Console.WriteLine("\r\nHello and Welcome to Don't Quote Me On That.");
            Console.WriteLine("\r\nWe will be keeping track of all your favorite quotes from your favorite books!");
            Console.WriteLine("\r\nWe will also be telling you how many words are in that quote.");

            //Next, I want to create a Dictionary to hold each of the book titles and their associated quote.
            //The Key should be the title of the book. The value pair should be a string as well and the user's
            //favorite quote from the book.
            Dictionary<string, string> favoriteBooksAndQuotes = new Dictionary<string, string>();

            //Create a menu system to hold 4 options: Add A Book, Retreieve A Quote, See Instructions and Exit Program.

            //Create a bool variable to keep the menu running.
            bool keepMenuRunning = true;

            //Create the while loop to keep the menu running.
            while (keepMenuRunning)
            {
                //Tell the user the options inside of the menu.
                Console.WriteLine("(1) Add A Book");

                Console.WriteLine("(2) Retrieve A Quote");

                Console.WriteLine("(3) See Instructions");

                Console.WriteLine("(4) Exit Program");

                //Tell the user to select an option from the above menu.

                //Listen for the user's input.
                string menuSelection = Console.ReadLine();

                //This is the validation loop for menuSelection.
                while (menuSelection != "1" && menuSelection != "2" && menuSelection != "3" && menuSelection != "4")
                {
                    //Tell the user the error.
                    Console.WriteLine("\r\nPlease only type in 1,2,3 or 4!");

                    //Re-state the question/instructions.
                    Console.WriteLine("\r\n");

                    //Re-prompt the user using the same string variable.
                    menuSelection = Console.ReadLine();
                }

                //Next, I want to implement the menu's functions.
                //I can use a conditional statement for this.
                if (menuSelection == "1")
                {
                    //Add A Book
                    favoriteBooksAndQuotes = AddABook(favoriteBooksAndQuotes);
                }
                else if (menuSelection == "2")
                {
                    //Retrieve A Quote
                    RetrieveAQuote(favoriteBooksAndQuotes);
                }
                else if (menuSelection == "3")
                {
                    //See Instructions
                    PrintInstructions();
                }
                else if (menuSelection == "4")
                {
                    //Exit Program

                    //Be sure to thank the user and bid farewell.
                    Console.WriteLine("Thank you for using my program!\r\nGoodbye!");

                    //Change the boolean variable that controls the loop to false.
                    keepMenuRunning = false;
                }

                //Pause the menu system
                Console.WriteLine("\r\nPlease press ENTER to continue.");
                Console.ReadLine();

                //Clear the console
                Console.Clear();
            }//End of the while loop for the main menu.
        }//End of Main Method

        //Create a function for MenuOption1(Add A Book)
        public static Dictionary<string, string> AddABook(Dictionary<string, string> DD)
        {
            //Clear the screen
            Console.Clear();

            //Tell the user what they are doing.
            Console.WriteLine("\r\nGreat! Let's add a book title to your library!");

            //Prompt the user for a string that represents the book title. Give an example.
            Console.WriteLine("\r\nPlease type in one of your favorite book titles:");

            //Example book title.
            Console.WriteLine("\r\nFor example: Alice In Wonderland");

            //Listen for the user's input/response.
            string bookTitle = Console.ReadLine();

            //Validation - be sure it not left blank and that it is not already in the Dictionary.
            while (string.IsNullOrWhiteSpace(bookTitle) || DD.ContainsKey(bookTitle))
            {
                //Tell the user.
                Console.WriteLine("\r\nPlease do not leave this field blank.\r\nMake sure you do not add a book title that is already in your library.");

                //Re-state the question.
                Console.WriteLine("\r\nPlease type in one of your favorite book titles:");

                //Re-prompt the user using the same string variable.
                bookTitle = Console.ReadLine();
            }

            //Tell the user you got their response
            Console.WriteLine("\r\nGot it! {0} is an awesome book!",bookTitle);

            //Ask the user for their favorite quote.
            Console.WriteLine("\r\nNow what is your favorite quote from {0}?", bookTitle);

            //Listen for the user's input.
            string bookQuote = Console.ReadLine();

            //Validation - be sure it is not left blank
            while (string.IsNullOrWhiteSpace(bookQuote) || DD.ContainsValue(bookQuote))
            {
                //Tell the user
                Console.WriteLine("\r\nPlease do not left this blank.\r\nMake sure you do not add a quote that already exisits in your book collection.");

                //Re-state the question/instructions.
                Console.WriteLine("\r\nNow what is your favorite quote from {0}?", bookTitle);

                //Listen for the user's input.
                bookQuote = Console.ReadLine();
            }

            //Add the bookTitle and bookQuote to the Dictionary.
            DD.Add(bookTitle, bookQuote);

            //return the Dictionary back to the Main Method.
            return DD;
        }

        //Next, I want to create another custom function for MenuOption2(Retrieve A Quote)
        public static void RetrieveAQuote(Dictionary<string, string> DD)
        {
            //Clear the console.
            Console.Clear();

            //Check the dictionary to make sure it is not blank or empty.
            if (DD.Count == 0)
            {
                //If the dictionary is empty
                //Tell the user to add at least (1) book and quote.
                Console.WriteLine("\r\nYou must add at least (1) book and quote to retrieve and a quote.");
            }
            else
            {
                //This will run if the Dictionary is not empty

                //Show header
                Console.WriteLine("Your Book List:");

                //Use a foreach loop to display a list of the user's selected books.
                foreach (KeyValuePair<string, string> title in DD)
                {
                    //Output the book titles
                    Console.WriteLine(title.Key);
                }

                //Tell the user how many books they have in their library to make sure the dictionary is populating.
                Console.WriteLine("\r\nYou have {0} book(s) and {1} quote(s) in the your library.",DD.Keys.Count, DD.Values.Count);

                //Tell the user to pick a book title.
                Console.WriteLine("\r\nPlease choose a book title from the list above\r\nI can tell you your favorite quote from it and how many words are in it.");

                //Listen for their input
                string bookTitle = Console.ReadLine();

                //Validate that only books available on the list can be choosen.
                while (!DD.ContainsKey(bookTitle))
                {
                    //Tell the user the error.
                    Console.WriteLine("\r\nPlease only choose a book title from the list above.\r\nBe sure to type it in exactly as you see it above!");

                    //Re-state the question/instructions.
                    Console.WriteLine("\r\nPlease choose a book title from the list above\r\nI can tell you your favorite quote from it and how many words are in it.");

                    //Re-prompt the user for their input/response.
                    bookTitle = Console.ReadLine();
                }

                //Function call and store return in a variable
                int wordCounter = CountWords(DD[bookTitle]);

                //final Output
                Console.WriteLine("\r\nYour favorite quote from {0} is:\r\n\r\n{1}\r\n\r\nThere are {2} words in the quote.",bookTitle, DD[bookTitle], wordCounter);

            }//End of the else statement

        }//End of RetrieveAQuote function
        public static void PrintInstructions()
        {
            //Create a string array
            string[] instructionsArray = new string[] {"\r\nPress (1) and add a favorite book and your favorite quote from the book to your library."
                                                        , "\r\nPress (2) to Retrieve a Quote from your library of books."
                                                        , "\r\nNext, press (3) to review the instructions for this program."
                                                        , "\r\nLastly, press (4) to exit the program."};
            foreach (string rule in instructionsArray)
            {
                Console.WriteLine(rule);
            }
                                                        
        }

        //Finally, create a function for PrintInstructions(MenuOption3)

        //Create a custom function called CountWords.
        public static int CountWords(string sentence)
        {
            //Need an integer variable to store the number of words.
            int wordCounter = 0;

            //Create a string array that splits up the words
            string[] sentenceArray = sentence.Split(" ");

            foreach (string word in sentenceArray)
            {
                wordCounter++;
            }
            
           //Return number value
           return wordCounter;  
        }

    }//End of the Program
}//End of the Namespace
