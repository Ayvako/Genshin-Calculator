using Newtonsoft.Json;

namespace Genshin.src
{
    public class Character
    {
        public string Name { get; private set; }
        public int Priority { get; set; }
        public string Current_level { get; set; }
        public string Desired_level { get; set; }
        public Skill Auto_attack { get; set; }
        public Skill Elemental { get; set; }
        public Skill Burst { get; set; }
        public bool Is_deleted { get; set; }
        public bool Is_activated { get; set; }
        [JsonIgnore]
        public string Local_specialty { get; private set; }
        [JsonIgnore]
        public string Element { get; private set; }
        [JsonIgnore]
        public string Weapon { get; private set; }
        [JsonIgnore]
        public string Enemy { get; private set; }
        [JsonIgnore]
        public string Mini_boss { get; private set; }
        [JsonIgnore]
        public string Weekly_boss { get; private set; }
        [JsonIgnore]
        public string Book_type { get; set; }
        private static int Count { get; set; }
        public Character(string name, string weapon, string element, string local_specialty, string book_type, string enemy, string mini_boss, string weekly_boss)
        {
            Name = name;
            Local_specialty = local_specialty;
            Book_type = book_type;
            Element = element;
            Weapon = weapon;
            Enemy = enemy;
            Mini_boss = mini_boss;
            Auto_attack = new Skill();
            Elemental = new Skill();
            Burst = new Skill();
            Weekly_boss = weekly_boss;
            Current_level = "1";
            Desired_level = "1";
            Is_deleted = true;
            Priority = ++Count;
        }
    }

    public class Skill
    {
        public int Current_level { get; set; }
        public int Desired_level { get; set; }
        public Skill(int current_level = 1, int desired_level = 1)
        {
            Current_level = current_level;
            Desired_level = desired_level;
        }
    }
    public class Element
    {
        public const string ANEMO = "Anemo";
        public const string HYDRO = "Hydro";
        public const string GEO = "Geo";
        public const string PYRO = "Pyro";
        public const string CRYO = "Cryo";
        public const string ELECTRO = "Electro";
        public const string DENDRO = "Dendro";
    }
    public class Weapon
    {
        public const string BOW = "Bow";
        public const string SWORD = "Sword";
        public const string CLAYMORE = "Claymore";
        public const string CATALYST = "Catalyst";
        public const string POLEARM = "Polearm";
    }
}