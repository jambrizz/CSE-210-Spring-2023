using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Console;

public class DisplayHelper
{
    private List<string> startingMessages = new List<string>()
    {
        "You have just gotten back into town after a fighting some dark goblins on the high country east of the shadow forest. \nYou are tired and hungry. You decide to go to the local tavern to get some food and rest.",
        "You walk into the tavern and see a few people sitting at the bar. \nYou walk up to the bar and order some food and a drink. You sit down at a table and begin to eat.",
        "You over hear the people at the bar talking about a monster that has taken up residence in the abandoned king's tower in the lookout plateau northwest of the town. \nYou decide to go talk to them to see if you can get more information.",
        "A man in a ranger's cloak tells you that nobody knows what kind of monster it is since everyone who has faced it has not survived to tell the tale. \nHe also tells you that the king's tower is a very dangerous place and that you should not go there.",
        "His companion tells you he has heard rumors that the monster is guarding a treasure of some kind. \nHe also tells you that the monster is very powerful and that you should not go there. \nIf you value your life.",
        "You ask if they know anything else about the Monster",
        "They say that is all they know and pray that you are not foolish enough to go there.",
        "A mysterious man wearing a old suit of armor that has seen better days walks up to you and says nothing but hands you a old map. \nHe then walks out of the tavern.",
        "You open the map and see that it is a map to king's tower. \nYou notice that there are 3 paths leading up to the tower but the map is too old and beat up to make out the descriptions of the paths. \nThe only thing you can see clearly is where the paths split off from the lonely travelers passage.",
        "You decide to get some rest and head out in the morning.",
        "You wake up the next morning and head out to the lonely travelers passage.",
        "You arrive at the lonely travelers passage and see the 3 paths leading up to a distant plateau. \nYou look at the map and recognize the surroundings.",
        "You notice what appears to be a carving on a boulder near the split in the path. \nYou walk over to the boulder and see that there are 3 symbols carved into the boulder.",
        "The symbols are a river, a mountain, and a forest. You look at the map and see that the paths are labeled with the same symbols. \nHowever the map is too faded to make out the descriptions of the paths."
    };

    public void DisplayTitle()
    {
        Console.Clear();
        string filename = "title.txt";
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    public void DisplayMenu()
    {
        string filename = "Menu.txt";
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    public void DisplayStartingMessages()
    {
        Console.Clear();
        foreach (string message in startingMessages)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public void DisplayTextFile(string file)
    {
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }
}