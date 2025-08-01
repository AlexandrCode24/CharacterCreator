using System.Text.Json;

namespace CharacterCreator
{
    public static class CharacterUtils
    {
        //Display enums to user for selection of class or race

        public static T PromptEnumSelection<T>(string label) where T : Enum
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

        public static void SetCharacterData(Character character)
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
        public static void SetStartingInventory(Character character)
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

        //methods to save and load file
        private const string fileName = "character.json";
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        public static void SaveCharacter(Character character)
        {
            try
            {
                string characterString = JsonSerializer.Serialize(character, jsonOptions);
                File.WriteAllText(fileName, characterString);
                
            }
            catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Permission error: {ex.Message}");
                }
            catch (IOException ex)
                {
                    Console.WriteLine($"File write error: {ex.Message}");
                }
            catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
        }

        public static Character? LoadCharacter()
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("Character Loaded.\n");
                string loadedCharacter = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<Character>(loadedCharacter, jsonOptions);
            }
            else
            {
                Console.WriteLine("Character data not found.");
                return null;
            }
        }

        public static int AcceptUserInputInRange(int min, int max)
        {
            int userInput;
            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out userInput) && userInput >= min && userInput <= max)
                {
                    return userInput;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }

    }
}