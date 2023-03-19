using Genshin.src.LevelingResources;
using Genshin.src.Upgredes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genshin.src
{
    public static class Inventory
    {
        static Dictionary<string, int> My_inventory = new();
        static Dictionary<string, int> Copy_of_inventory = new();
        static List<Character> Characters = new();
        static Dictionary<Character, List<Material>> Required_materials = new();

        public static Dictionary<Character, List<Material>> CalcRequiredMaterials()
        {
            List<Character> List_of_active_characters = GetActiveCharacters();
            Dictionary<Character, List<Material>> Materials_for_characters = new();
            List<Material> temp = new();
            int exp = (Copy_of_inventory["HerosWit"] * 20 + Copy_of_inventory["AdventurersExperience"] * 5 + Copy_of_inventory["WanderersAdvice"] * 1);
            foreach (var character in List_of_active_characters)
            {
                exp = CalcExp(character, temp, exp);

                foreach (var m in TotalCost(character))
                {

                    if (m.Name == "HerosWit") continue;
                    if (m.Name == "AdventurersExperience") continue;
                    if (m.Name == "WanderersAdvice") continue;

                    if (Copy_of_inventory[m.Name] < m.Amount && m.Name != "WanderersAdvice")
                    {
                        temp.Add(new Material(m.Name, m.Amount - Copy_of_inventory[m.Name]));
                        Copy_of_inventory[m.Name] = 0;
                    }
                    else if (Copy_of_inventory[m.Name] >= m.Amount && m.Name != "WanderersAdvice")
                    {
                        temp.Add(new Material(m.Name, 0));
                        Copy_of_inventory[m.Name] -= m.Amount;
                    }
                }

                Materials_for_characters.Add(character, new List<Material>(temp));
                temp.Clear();
            }
            return Materials_for_characters;
        }

        public static int CalcExp(Character c, List<Material> inventory, int exp)
        {
            var materaials = TotalCost(c);

            foreach (var m in materaials)
                if (m.Name == "WanderersAdvice" && exp < m.Amount)
                {
                    inventory.Add(new Material(m.Name, m.Amount - exp));
                    exp = 0;
                }
                else if (m.Name == "WanderersAdvice" && exp >= m.Amount)
                {
                    inventory.Add(new Material(m.Name, 0));
                    exp -= m.Amount;
                }
            return exp;
        }
        public static List<Character> GetAllCharacters()
        {
            return Characters;
        }
        public static List<Character> GetActiveCharacters()
        {
            if (Characters != null)
                return Characters.FindAll(c => c.Is_activated == true);
            else return new List<Character>();
        }
        public static List<Character> GetDisabledCharacters()
        {
            if (Characters != null)
                return Characters.FindAll(c => c.Is_activated == false);
            else return new List<Character>();
        }
        public static List<Character> GetDeletedCharacters()
        {
            if (Characters != null)
                return Characters.FindAll(c => c.Is_deleted == true);
            else return new List<Character>();
        }
        public static List<Character> GetNotDeletedCharacters()
        {
            if (Characters != null)
                return Characters.FindAll(c => c.Is_deleted == false);
            else return new List<Character>();
        }
        public static void AddCharacter(Character character) => character.Is_deleted = false;
        public static void CharacrerLevelUp(Character character, string to) => character.Desired_level = to;
        public static void AAChangeLevel(Character character, int to) => character.Auto_attack.Desired_level = to;
        public static void ElemChangeLevel(Character character, int to) => character.Elemental.Desired_level = to;
        public static void BurstChangeLevel(Character character, int to) => character.Burst.Desired_level = to;
        public static void Export()
        {
            var materialsJson = JsonConvert.SerializeObject(My_inventory, Formatting.Indented);
            var charactersJson = JsonConvert.SerializeObject(Characters, Formatting.Indented);

            var exportJson = new JObject
            {
                ["Materials"] = JToken.Parse(materialsJson),
                ["Characters"] = JToken.Parse(charactersJson)
            };

            var exportString = exportJson.ToString(Formatting.Indented);
            File.WriteAllText("Export.json", exportString);

            Console.WriteLine("Export");
        }
        public static void Import()
        {
            var init_Json = JObject.Parse(File.ReadAllText("Initializations.json"));
            var update_Json = JObject.Parse(File.ReadAllText("Export.json"));

            My_inventory = DeserializeInventory(init_Json["Materials"].ToString());
            Characters = DeserializeCharacters(init_Json["Characters"].ToString());
            if (update_Json["Materials"] != null)
            {
                My_inventory = DeserializeInventory(update_Json["Materials"].ToString());
                var update_characters = DeserializeCharacters(update_Json["Characters"].ToString());

                foreach (var character in Characters)
                {
                    var updateCharacter = update_characters.FirstOrDefault(c => c.Name == character.Name);
                    if (updateCharacter == null) continue;
                    character.Priority = updateCharacter.Priority;
                    character.Current_level = updateCharacter.Current_level;
                    character.Desired_level = updateCharacter.Desired_level;
                    character.Auto_attack = updateCharacter.Auto_attack;
                    character.Elemental = updateCharacter.Elemental;
                    character.Burst = updateCharacter.Burst;
                    character.Is_deleted = updateCharacter.Is_deleted;
                    character.Is_activated = updateCharacter.Is_activated;
                }

            }
            Copy_of_inventory = CopyDictionary(My_inventory);
            Console.WriteLine("Import");
        }
        private static Dictionary<string, int> DeserializeInventory(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        }
        private static List<Character> DeserializeCharacters(string json)
        {
            return JsonConvert.DeserializeObject<List<Character>>(json);
        }
        public static void ChangePriority(Character c1, Character c2) => (c2.Priority, c1.Priority) = (c1.Priority, c2.Priority);
        public static void AddMaterial(Material material, int amount) => material.Amount += amount;
        public static void SetMaterial(Material material, int amount) => material.Amount = amount;
        public static void Upgrade(Character character)
        {
            Required_materials = CalcRequiredMaterials();
            if (IsUpgradable(Required_materials[character]))
            {
                character.Current_level = character.Desired_level;

                Skill auto_attack = character.Auto_attack;
                Skill elemental = character.Elemental;
                Skill burst = character.Burst;

                auto_attack.Current_level = auto_attack.Desired_level;
                elemental.Current_level = elemental.Desired_level;
                burst.Current_level = burst.Desired_level;

                foreach (var m in Required_materials[character])
                    My_inventory[m.Name] -= m.Amount;

                Required_materials = CalcRequiredMaterials();
                Copy_of_inventory = CopyDictionary(My_inventory);
            }
            else Console.WriteLine($"{character} Error Upgrade");
        }
        public static void EnableCharacter(Character character) => character.Is_activated = true;
        public static void DisableCharacter(Character character) => character.Is_activated = false;
        public static void DeleteCharacter(Character character) => character.Is_deleted = true;
        private static bool IsUpgradable(List<Material> materials)
        {
            return materials.All(m => m.Amount == 0);
        }
        private static Dictionary<string, int> CopyDictionary(Dictionary<string, int> old)
        {
            return new Dictionary<string, int>(old);
        }
        private static List<Material> TotalCost(Character character)
        {
            var merg = MergDictionaries(CharacterCost(character), SkillsCost(character));
            return merg.Select(v => new Material(v.Key, v.Value)).ToList();
        }
        private static Dictionary<string, int> CharacterCost(Character character)
        {
            return CharacterUpgrade.GetCost(character, character.Current_level, character.Desired_level);
        }
        private static Dictionary<string, int> SkillsCost(Character character)
        {
            Skill auto_attack = character.Auto_attack;
            Skill elemental = character.Elemental;
            Skill burst = character.Burst;

            Dictionary<string, int> materialsForAA = SkillUpgrade.GetCost(character, auto_attack.Current_level, auto_attack.Desired_level);
            Dictionary<string, int> materialsForElem = SkillUpgrade.GetCost(character, elemental.Current_level, elemental.Desired_level);
            Dictionary<string, int> materialsForBurst = SkillUpgrade.GetCost(character, burst.Current_level, burst.Desired_level);
            return MergDictionaries(materialsForAA, materialsForElem, materialsForBurst);
        }
        private static Dictionary<string, int> MergDictionaries(params Dictionary<string, int>[] dictionaries)
        {
            // объединяем все словари в один перечислимый список пар ключ-значение
            IEnumerable<KeyValuePair<string, int>> merged = dictionaries[0];
            for (int i = 1; i < dictionaries.Length; i++)
                merged = merged.Concat(dictionaries[i]);
            // создаем из списка словарь, где значения с одинаковыми ключами складываются
            Dictionary<string, int> result = merged
                .ToLookup(kvp => kvp.Key, kvp => kvp.Value)
                .ToDictionary(group => group.Key, group => group.Sum(x => x));
            return result;
        }
    }
}