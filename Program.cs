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
                Console.WriteLine("2: Load Character");
                Console.WriteLine("3: Exit");

                int userInput = CharacterUtils.AcceptUserInputInRange(1, 3);
                switch (userInput)
                {
                    case 1:
                        Character character = new Character();
                        CharacterUtils.SetCharacterData(character);
                        CharacterUtils.SetStartingInventory(character);
                        character.DisplayCharacter();
                        Console.WriteLine("Would you like to save this character? (1: Yes | 2: No)");

                        if (CharacterUtils.AcceptUserInputInRange(1, 2) == 1)
                        {
                            CharacterUtils.SaveCharacter(character);
                            Console.WriteLine("Character saved successfully.");
                        }
                        break;
                    case 2:
                        var loadedCharacter = CharacterUtils.LoadCharacter();
                        loadedCharacter?.DisplayCharacter();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("\nGoodbye");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;

                }
                
            }

        }
        
    }
}


    
