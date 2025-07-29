using System.Diagnostics;
using System.Globalization;

namespace CharacterCreator
{
    public class Character
    {
        public string? Name { get; set; }
        public Race Race { get; set; }
        public CharacterClass Class { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public List<string> Inventory { get; set; }


        public Character()
        {
            Stats = new Dictionary<string, int>
            {
                ["Strength"] = 10,
                ["Dexterity"] = 10,
                ["Constitution"] = 10,
                ["Intelligence"] = 10,
                ["Wisdom"] = 10,
                ["Charisma"] = 10
            };
            Inventory = new List<string>();
        }
        //Method should display character name, race, class, current stats and current inventory
        public void DisplayCharacter()
        {
            Console.WriteLine(@$"Your Character: 
            Name: {Name} 
            Race: {Race}
            Class: {Class}
            Stats: ");

            foreach (var kvp in Stats)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            if (Inventory.Count == 0)
            {
                Console.WriteLine("Inventory: Empty");
            }
            else
            {
                Console.WriteLine("Inventory: ");
                foreach (string item in Inventory)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
    
}