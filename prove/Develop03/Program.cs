using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 1; i++)
        {
            int selection = 0;
            bool featureSelection = false;
            while (featureSelection == false)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Scripture Memorization Program!");
                Console.WriteLine("Please select what type of scripture you would like to practice memorizing:");
                Console.WriteLine("1. Single Verse");
                Console.WriteLine("2. Multiple Verses");
                Console.WriteLine("3. Quit");
                Console.Write("> ");
                string featureSelectionString = Console.ReadLine();
                bool featureSelectionBool = int.TryParse(featureSelectionString, out int featureSelectionInt);
                if (featureSelectionBool == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid number.");
                    
                }
                else if(featureSelectionBool == true && featureSelectionInt > 3 || featureSelectionInt < 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You entered the number {featureSelectionInt} which is not a valid option. Please try again.");
                }
                else if(featureSelectionBool == true && featureSelectionInt == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Scripture Memorization Program. Goodbye!");
                    //This line of code below is used to exit the program without trigerring the switch.
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine();
                    selection = featureSelectionInt;
                    featureSelection = true;
                }
            }
            
            switch (selection)
            {
                //TODO: finish case 1.
                case 1:
                    string file = "singleverse.txt";
                    ScriptureLibrary library = new ScriptureLibrary(file);
                    library.GetLengthOfTextFile();
                    library.GetRandomScripture();
                    string text = library.LoadScripturesFromFiles();                  
                    Scriptures scripture = new Scriptures(text);
                    scripture.ExtractReference();
                    string verse = scripture.ExtractVerse();
                    string rawRef = scripture.ExtractReference();
                    Reference reference = new Reference(rawRef);
                    reference.SetRefernces();
                    string referenceToDisplay = reference.GetReferenceSingleVerse();
                    Word word = new Word();
                    word.AddVerseToList(verse);
                    string rawVerse = word.DisplayVerse();
                    Console.Clear();
                    Console.WriteLine($"{referenceToDisplay} {rawVerse}");
                    Console.WriteLine("Press enter to continue or type 'quit' to finish.");
                    Console.Write("> ");
                    string userAction1 = Console.ReadLine().ToLower();
                ////////////////////This is where I left off/////////////////////
                //TODO: finish case 1. the issue is that the program doesn't end right after all the words are hidden. you have to hit enter again to end the program.
                    bool userInput1 = false;
                    while(userInput1 == false)
                    {
                        /*
                        Console.WriteLine($"{referenceToDisplay} {rawVerse}\n\n Press enter to continue or type 'quit' to finish.");
                        Console.Write("> ");
                        string userAction1 = Console.ReadLine().ToLower();
                        if(userAction1 == "")
                        {
                            Console.WriteLine();
                            Console.WriteLine("You hit enter.");
                            userInput1 = true;
                        }
                        else if(userAction1 == "quit")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Thank you for using the Scripture Memorization Program. Goodbye!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid selection please try again.");
                        }
                        */
                    }
                    /*
                    bool programRun = false;
                    while(programRun == false)
                    {
                        word.HideText();
                        string hiddenWordVerse = word.DisplayVerseWithHiddenWords();
                        Console.WriteLine($"{referenceToDisplay} {hiddenWordVerse}");
                        Console.Write("> ");
                        string userAction2 = Console.ReadLine().ToLower();
                        if(userAction2 == "")
                        {
                            bool programComplete = word.CheckIfComplete();
                            if(programComplete == true)
                            {
                                programRun = true;
                            }
                            Console.Clear();
                            word.HideText();
                            word.DisplayVerseWithHiddenWords();
                            Console.WriteLine($"{referenceToDisplay} {hiddenWordVerse}");

                        }
                        else if(userAction2 == "quit")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Thank you for using the Scripture Memorization Program. Goodbye!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid selection please try again.");
                        }
                    }
                    */
                    break;
                case 2:
                    Console.WriteLine("You selected Multiple Verses.");
                    break;
                default:
                    break;
            }
        }
    }
}