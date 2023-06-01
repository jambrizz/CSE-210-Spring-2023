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
                    Console.WriteLine();
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
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue or type 'quit' to finish.");
                    Console.Write("> ");
                    string userAction1 = Console.ReadLine().ToLower();
                
                    bool userInput1 = false;
                    while(userInput1 == false)
                    {

                        if (userAction1 == "")
                        {
                            Console.Clear();
                            word.HideText();
                            string hiddenWordVerse = word.DisplayVerseWithHiddenWords();
                            Console.WriteLine($"{referenceToDisplay} {hiddenWordVerse}");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
                            Console.Write("> ");
                            userAction1 = Console.ReadLine().ToLower();
                        }
                        else if (userAction1 == "quit")
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

                        bool programComplete = word.CheckIfComplete();
                        if (programComplete == true)
                        {
                            userInput1 = true;
                            Console.WriteLine();
                            Console.WriteLine("You have completed this scripture. See you next time!");
                            Console.WriteLine();
                        }
                    }
                    break;
                case 2:
                    string file2 = "multipleverses.txt";
                    ScriptureLibrary library2 = new ScriptureLibrary(file2);
                    library2.GetLengthOfTextFile();
                    library2.GetRandomScripture();
                    string text2 = library2.LoadScripturesFromFiles();
                    Scriptures scripture2 = new Scriptures(text2);
                    string rawRef2 = scripture2.ExtractReference();
                    string verse2 = scripture2.ExtractVerse();
                    Reference reference2 = new Reference(rawRef2);
                    reference2.SetMultipleVerses();
                    string referenceToDisplay2 = reference2.GetReferenceMultipleVerses();
                    Word word2 = new Word();
                    word2.AddVerseToList(verse2);
                    string rawVerse2 = word2.DisplayVerse();
                    Console.Clear();
                    Console.WriteLine($"{referenceToDisplay2} {rawVerse2}");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue or type 'quit' to finish.");
                    Console.Write("> ");
                    string userAction2 = Console.ReadLine().ToLower();

                    bool userInput2 = false;
                    while(userInput2 == false)
                    {
                        if (userAction2 == "")
                        {
                            Console.Clear();
                            word2.HideText();
                            string hiddenWordVerse2 = word2.DisplayVerseWithHiddenWords();
                            Console.WriteLine($"{referenceToDisplay2} {hiddenWordVerse2}");
                            Console.WriteLine();
                            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
                            Console.Write("> ");
                            userAction2 = Console.ReadLine().ToLower();
                        }
                        else if (userAction2 == "quit")
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

                        bool programComplete2 = word2.CheckIfComplete();
                        if (programComplete2 == true)
                        {
                            userInput2 = true;
                            Console.WriteLine();
                            Console.WriteLine("You have completed this scripture. See you next time!");
                            Console.WriteLine();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}