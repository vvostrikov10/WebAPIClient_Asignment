using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace WebAPIClient
{
    class Monster
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }

        [JsonProperty("hit_points")]
        public int Hit_points { get; set; }

        [JsonProperty("strength")]
        public int Strength { get; set; }

        [JsonProperty("dexterity")]
        public int Dexterity { get; set; }

        [JsonProperty("constitution")]
        public int Constitution { get; set; }

        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }
        [JsonProperty("wisdom")]
        public int Wisdom { get; set; }

        [JsonProperty("charisma")]
        public int Charisma { get; set; }
    }
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {
            Console.WriteLine("This is a dnd monster manual, Some monsters to try: Lich, Rakshasa, Goblin");
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a monster name. Press Enter without writing a name to quit the program.");

                    var monsterName = Console.ReadLine();

                    if (string.IsNullOrEmpty(monsterName))
                    {
                        break;
                    }
                    var result = await client.GetAsync("https://www.dnd5eapi.co/api/monsters/" + monsterName.ToLower());
                    var resultRead = await result.Content.ReadAsStringAsync();

                    var monster = JsonConvert.DeserializeObject<Monster>(resultRead);
                    Console.WriteLine("---");
                    Console.WriteLine("Monster name: " + monster.Name);
                    Console.WriteLine("Monster size: " + monster.Size);
                    Console.WriteLine("Monster alignment: " + monster.Alignment);
                    Console.WriteLine("Monster Hit points: " + monster.Hit_points);
                    Console.WriteLine("Monster Strength score: " + monster.Strength);
                    Console.WriteLine("Monster Dexterity score: " + monster.Dexterity);
                    Console.WriteLine("Monster Constitution score: " + monster.Constitution);
                    Console.WriteLine("Monster Intelligence score: " + monster.Intelligence);
                    Console.WriteLine("Monster Wisdom score: " + monster.Wisdom);
                    Console.WriteLine("Monster Charisma score: " + monster.Charisma);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Please enter a proper monster name.");
                }
            }
        }
    }
}