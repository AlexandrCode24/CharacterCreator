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
                    SetStartingInventory(character);
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

            //This section modifies the main stats based on character class
            switch (character.Class)
            {
                case CharacterClass.Warrior:
                    character.Stats["Strength"] = 15;
                    character.Stats["Constitution"] = 20;
                    break;
                case CharacterClass.Mage:
                    character.Stats["Intelligence"] = 20;
                    character.Stats["Wisdom"] = 15;
                    break;
                case CharacterClass.Rogue:
                    character.Stats["Dexterity"] = 20;
                    character.Stats["Strength"] = 15;
                    break;
                case CharacterClass.Cleric:
                    character.Stats["Wisdom"] = 20;
                    character.Stats["Charisma"] = 15;
                    break;

            }
        }

        //This method assigns starter items based on character class.
        static void SetStartingInventory(Character character)
        {
            switch (character.Class)
            {
                case CharacterClass.Warrior:
                    character.Inventory.Add("Rusty Sword");
                    character.Inventory.Add("Old Shield");
                    break;
                case CharacterClass.Mage:
                    character.Inventory.Add("Wooden Staff");
                    character.Inventory.Add("Mana Potion");
                    break;
                case CharacterClass.Rogue:
                    character.Inventory.Add("Rusty Dagger");
                    character.Inventory.Add("Lockpick");
                    break;
                case CharacterClass.Cleric:
                    character.Inventory.Add("Old Tome");
                    character.Inventory.Add("Mana Potion");
                    break;
                
            }
        }
    }
}


    
