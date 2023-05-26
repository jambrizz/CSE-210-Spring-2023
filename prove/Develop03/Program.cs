using System;

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
                    Console.WriteLine("You selected Single Verse.");
                    string file = "singleverse.txt";
                    ScriptureLibrary library = new ScriptureLibrary(file);
                    library.GetLengthOfTextFile();
                    library.GetRandomScripture();
                    //Console.WriteLine(library.GetRandom());
                    library.LoadScripturesFromFiles();                  
                    Scriptures scripture = new Scriptures();
                    scripture.GetDisplayText();
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