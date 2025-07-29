using System; // allows access to basic system functions console, math etc.
using System.Collections;
using System.Collections.Generic; //allows use of List<T> and dictionary<T>
using System.Diagnostics;
using System.Linq.Expressions;
using CharacterCreator;

namespace CharacterCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            // Get character name from user
            while (running)
            {
                Console.WriteLine("Welcome to RPG Character Creator.");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Options: ");
                Console.WriteLine("1: Create New Character");
                Console.WriteLine("2: Exit");

                string? userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Character character = new Character();

                    //set the characteristics of your character
                    SetCharacterData(character);
                    character.DisplayCharacter();
                }
                if (userInput == "2")
                {
                    Console.WriteLine("\nGoodbye");
                    running = false;
                }
            }

        }
 //Display enums to user for selection of class or race

static T PromptEnumSelection<T>(string label) where T : Enum
{
    Console.WriteLine($"\nChoose your desired {label}:");

    var values = Enum.GetValues(typeof(T));
    int index = 1;

    foreach (var value in values)
    {
        Console.WriteLine($"{index}: {value}");
        index++;
    }

    while (true)
    {
        Console.Write($"Enter a number for your desired {label}: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= values.Length)
        {
            return (T)values.GetValue(choice - 1)!;
        }
        Console.WriteLine("Invalid input. Please Try again.");
    }
}

static void SetCharacterData(Character character)
{
    //set name
    string? inputName;
    do
    {
        Console.WriteLine("Enter Desired character Name:  ");
        inputName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputName))
        {
            Console.WriteLine("Name cannot be blank.");
        }
    } while (string.IsNullOrWhiteSpace(inputName));
    character.Name = inputName;

    //set race
    character.Race = PromptEnumSelection<Race>("Race");

    //set class
    character.Class = PromptEnumSelection<CharacterClass>("Class");          
}
    }
}

    
