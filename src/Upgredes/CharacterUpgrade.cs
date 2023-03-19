using Genshin.src.LevelingResources;

namespace Genshin.src.Upgredes
{
    public class CharacterUpgrade : Upgrade
    {
        public static Dictionary<string, int> GetCost(Character character, string from, string to)
        {
            Dictionary<string, int> Amount_of_materials_to_levelup = new();
            Dictionary<string, Material[]> Number_of_materials_for_levels = GetMaterialsForCharacter(character);

            int startIndex = levels.FindIndex(s => s.Contains(from));
            int endIndex = levels.FindIndex(s => s.Contains(to));

            var materialsInRange = levels.Skip(startIndex + 1).Take(endIndex - startIndex);

            foreach (var material in materialsInRange.SelectMany(level => Number_of_materials_for_levels[level]))
            {
                if (Amount_of_materials_to_levelup.ContainsKey(material.Name))
                {
                    Amount_of_materials_to_levelup[material.Name] += material.Amount;
                }
                else
                {
                    Amount_of_materials_to_levelup[material.Name] = material.Amount;
                }
            }
            //for (int i = startIndex + 1; i <= endIndex; i++)
            //{
            //    foreach (var v in Number_of_materials_for_levels[levels[i]])
            //        AddMaterialToMap(Amount_of_materials_to_levelup, v.Name, v.Amount);
            //}

            return Amount_of_materials_to_levelup;
        }
        private static Dictionary<string, Material[]> GetMaterialsForCharacter(Character character)
        {
            return new()
            {
                { "2", new Material[]  { new Material("WanderersAdvice", 1000 / 1000), new Material("Mora", 200) } },
                { "3", new Material[]  { new Material("WanderersAdvice", 1325 / 1000), new Material("Mora", 265) } },
                { "4", new Material[]  { new Material("WanderersAdvice", 1700 / 1000), new Material("Mora", 1700 / 5) } },
                { "5", new Material[]  { new Material("WanderersAdvice", 2150 / 1000), new Material("Mora", 2150 / 5) } },
                { "6", new Material[]  { new Material("WanderersAdvice", 2625 / 1000), new Material("Mora", 2625 / 5) } },
                { "7", new Material[]  { new Material("WanderersAdvice", 3150 / 1000), new Material("Mora", 3150 / 5) } },
                { "8", new Material[]  { new Material("WanderersAdvice", 3725 / 1000), new Material("Mora", 3725 / 5) } },
                { "9", new Material[]  { new Material("WanderersAdvice", 4350 / 1000), new Material("Mora", 4350 / 5) } },
                { "10", new Material[] { new Material("WanderersAdvice", 5000 / 1000), new Material("Mora", 5000 / 5) } },
                { "11", new Material[] { new Material("WanderersAdvice", 5700 / 1000), new Material("Mora", 5700 / 5) } },
                { "12", new Material[] { new Material("WanderersAdvice", 6450 / 1000), new Material("Mora", 6450 / 5) } },
                { "13", new Material[] { new Material("WanderersAdvice", 7225 / 1000), new Material("Mora", 7225 / 5) } },
                { "14", new Material[] { new Material("WanderersAdvice", 8050 / 1000), new Material("Mora", 8050 / 5) } },
                { "15", new Material[] { new Material("WanderersAdvice", 8925 / 1000), new Material("Mora", 8925 / 5) } },
                { "16", new Material[] { new Material("WanderersAdvice", 9825 / 1000), new Material("Mora", 9825 / 5) } },
                { "17", new Material[] { new Material("WanderersAdvice", 10750 / 1000), new Material("Mora", 10750 / 5) } },
                { "18", new Material[] { new Material("WanderersAdvice", 11725 / 1000), new Material("Mora", 11725 / 5) } },
                { "19", new Material[] { new Material("WanderersAdvice", 12725 / 1000), new Material("Mora", 12725 / 5) } },
                { "20", new Material[] { new Material("WanderersAdvice", 13775 / 1000), new Material("Mora", 13775 / 5) } },
                { "21", new Material[] { new Material("WanderersAdvice", 14875 / 1000), new Material("Mora", 14875 / 5) } },
                { "22", new Material[] { new Material("WanderersAdvice", 16800 / 1000), new Material("Mora", 16800 / 5) } },
                { "23", new Material[] { new Material("WanderersAdvice", 18000 / 1000), new Material("Mora", 18000 / 5) } },
                { "24", new Material[] { new Material("WanderersAdvice", 19250 / 1000), new Material("Mora", 19250 / 5) } },
                { "25", new Material[] { new Material("WanderersAdvice", 20550 / 1000), new Material("Mora", 20550 / 5) } },
                { "26", new Material[] { new Material("WanderersAdvice", 21875 / 1000), new Material("Mora", 21875 / 5) } },
                { "27", new Material[] { new Material("WanderersAdvice", 23250 / 1000), new Material("Mora", 23250 / 5) } },
                { "28", new Material[] { new Material("WanderersAdvice", 24650 / 1000), new Material("Mora", 24650 / 5) } },
                { "29", new Material[] { new Material("WanderersAdvice", 26100 / 1000), new Material("Mora", 26100 / 5) } },
                { "30", new Material[] { new Material("WanderersAdvice", 27575 / 1000), new Material("Mora", 27575 / 5) } },
                { "31", new Material[] { new Material("WanderersAdvice", 29100 / 1000), new Material("Mora", 29100 / 5) } },
                { "32", new Material[] { new Material("WanderersAdvice", 30650 / 1000), new Material("Mora", 30650 / 5) } },
                { "33", new Material[] { new Material("WanderersAdvice", 32250 / 1000), new Material("Mora", 32250 / 5) } },
                { "34", new Material[] { new Material("WanderersAdvice", 33875 / 1000), new Material("Mora", 33875 / 5) } },
                { "35", new Material[] { new Material("WanderersAdvice", 35550 / 1000), new Material("Mora", 35550 / 5) } },
                { "36", new Material[] { new Material("WanderersAdvice", 37250 / 1000), new Material("Mora", 37250 / 5) } },
                { "37", new Material[] { new Material("WanderersAdvice", 38975 / 1000), new Material("Mora", 38975 / 5) } },
                { "38", new Material[] { new Material("WanderersAdvice", 40750 / 1000), new Material("Mora", 40750 / 5) } },
                { "39", new Material[] { new Material("WanderersAdvice", 42575 / 1000), new Material("Mora", 42575 / 5) } },
                { "40", new Material[] { new Material("WanderersAdvice", 44425 / 1000), new Material("Mora", 44425 / 5) } },
                { "41", new Material[] { new Material("WanderersAdvice", 46300 / 1000), new Material("Mora", 50625 / 5) } },
                { "42", new Material[] { new Material("WanderersAdvice", 50625 / 1000), new Material("Mora", 50625 / 5) } },
                { "43", new Material[] { new Material("WanderersAdvice", 52700 / 1000), new Material("Mora", 52700 / 5) } },
                { "44", new Material[] { new Material("WanderersAdvice", 54775 / 1000), new Material("Mora", 54775 / 5) } },
                { "45", new Material[] { new Material("WanderersAdvice", 56900 / 1000), new Material("Mora", 56900 / 5) } },
                { "46", new Material[] { new Material("WanderersAdvice", 59075 / 1000), new Material("Mora", 59075 / 5) } },
                { "47", new Material[] { new Material("WanderersAdvice", 61275 / 1000), new Material("Mora", 61275 / 5) } },
                { "48", new Material[] { new Material("WanderersAdvice", 63525 / 1000), new Material("Mora", 63525 / 5) } },
                { "49", new Material[] { new Material("WanderersAdvice", 65800 / 1000), new Material("Mora", 65800 / 5) } },
                { "50", new Material[] { new Material("WanderersAdvice", 68125 / 1000), new Material("Mora", 68125 / 5) } },
                { "51", new Material[] { new Material("WanderersAdvice", 70475 / 1000), new Material("Mora", 70475 / 5) } },
                { "52", new Material[] { new Material("WanderersAdvice", 76500 / 1000), new Material("Mora", 76500 / 5) } },
                { "53", new Material[] { new Material("WanderersAdvice", 79050 / 1000), new Material("Mora", 79050 / 5) } },
                { "54", new Material[] { new Material("WanderersAdvice", 81650 / 1000), new Material("Mora", 81650 / 5) } },
                { "55", new Material[] { new Material("WanderersAdvice", 84275 / 1000), new Material("Mora", 84275 / 5) } },
                { "56", new Material[] { new Material("WanderersAdvice", 86950 / 1000), new Material("Mora", 86950 / 5) } },
                { "57", new Material[] { new Material("WanderersAdvice", 89650 / 1000), new Material("Mora", 89650 / 5) } },
                { "58", new Material[] { new Material("WanderersAdvice", 92400 / 1000), new Material("Mora", 92400 / 5) } },
                { "59", new Material[] { new Material("WanderersAdvice", 95175 / 1000), new Material("Mora", 95175 / 5) } },
                { "60", new Material[] { new Material("WanderersAdvice", 98000 / 1000), new Material("Mora", 98000 / 5) } },
                { "61", new Material[] { new Material("WanderersAdvice", 100875 / 1000), new Material("Mora", 100875 / 5) } },
                { "62", new Material[] { new Material("WanderersAdvice", 108950 / 1000), new Material("Mora", 108950 / 5) } },
                { "63", new Material[] { new Material("WanderersAdvice", 112050 / 1000), new Material("Mora", 112050 / 5) } },
                { "64", new Material[] { new Material("WanderersAdvice", 115175 / 1000), new Material("Mora", 115175 / 5) } },
                { "65", new Material[] { new Material("WanderersAdvice", 118325 / 1000), new Material("Mora", 118325 / 5) } },
                { "66", new Material[] { new Material("WanderersAdvice", 121525 / 1000), new Material("Mora", 121525 / 5) } },
                { "67", new Material[] { new Material("WanderersAdvice", 124775 / 1000), new Material("Mora", 124775 / 5) } },
                { "68", new Material[] { new Material("WanderersAdvice", 128075 / 1000), new Material("Mora", 128075 / 5) } },
                { "69", new Material[] { new Material("WanderersAdvice", 131400 / 1000), new Material("Mora", 131400 / 5) } },
                { "70", new Material[] { new Material("WanderersAdvice", 134775 / 1000), new Material("Mora", 134775 / 5) } },
                { "71", new Material[] { new Material("WanderersAdvice", 138175 / 1000), new Material("Mora", 138175 / 5) } },
                { "72", new Material[] { new Material("WanderersAdvice", 148700 / 1000), new Material("Mora", 148700 / 5) } },
                { "73", new Material[] { new Material("WanderersAdvice", 152375 / 1000), new Material("Mora", 152375 / 5) } },
                { "74", new Material[] { new Material("WanderersAdvice", 156075 / 1000), new Material("Mora", 156075 / 5) } },
                { "75", new Material[] { new Material("WanderersAdvice", 159825 / 1000), new Material("Mora", 159825 / 5) } },
                { "76", new Material[] { new Material("WanderersAdvice", 163600 / 1000), new Material("Mora", 163600 / 5) } },
                { "77", new Material[] { new Material("WanderersAdvice", 167425 / 1000), new Material("Mora", 167425 / 5) } },
                { "78", new Material[] { new Material("WanderersAdvice", 171300 / 1000), new Material("Mora", 171300 / 5) } },
                { "79", new Material[] { new Material("WanderersAdvice", 175225 / 1000), new Material("Mora", 175225 / 5) } },
                { "80", new Material[] { new Material("WanderersAdvice", 179175 / 1000), new Material("Mora", 179175 / 5) } },
                { "81", new Material[] { new Material("WanderersAdvice", 183175 / 1000), new Material("Mora", 183175 / 5) } },
                { "82", new Material[] { new Material("WanderersAdvice", 216225 / 1000), new Material("Mora", 216225 / 5) } },
                { "83", new Material[] { new Material("WanderersAdvice", 243025 / 1000), new Material("Mora", 243025 / 5) } },
                { "84", new Material[] { new Material("WanderersAdvice", 273100 / 1000), new Material("Mora", 273100 / 5) } },
                { "85", new Material[] { new Material("WanderersAdvice", 306800 / 1000), new Material("Mora", 306800 / 5) } },
                { "86", new Material[] { new Material("WanderersAdvice", 344600 / 1000), new Material("Mora", 344600 / 5) } },
                { "87", new Material[] { new Material("WanderersAdvice", 386950 / 1000), new Material("Mora", 386950 / 5) } },
                { "88", new Material[] { new Material("WanderersAdvice", 434425 / 1000), new Material("Mora", 434425 / 5) } },
                { "89", new Material[] { new Material("WanderersAdvice", 487625 / 1000), new Material("Mora", 487625 / 5) } },
                { "90", new Material[] { new Material("WanderersAdvice", 547200 / 1000), new Material("Mora", 547200 / 5) } },
                //перенести в файл

                

                { "20+", new Material[] { new Material($"{Gem.GetMaterial(character, "green")}",  1),  new Material($"{character.Local_specialty}", 3)                                             ,  new Material($"{Enemy.GetMaterial(character, "white")}",  3),   new Material("Mora", 20000) } },
                { "40+", new Material[] { new Material($"{Gem.GetMaterial(character, "blue")}",   3),  new Material($"{character.Local_specialty}", 10),  new Material($"{character.Mini_boss}", 2) ,  new Material($"{Enemy.GetMaterial(character, "white")}", 15),   new Material("Mora", 40000) } },
                { "50+", new Material[] { new Material($"{Gem.GetMaterial(character, "blue")}",   6),  new Material($"{character.Local_specialty}", 20),  new Material($"{character.Mini_boss}", 4) ,  new Material($"{Enemy.GetMaterial(character, "green")}", 12),   new Material("Mora", 60000) } },
                { "60+", new Material[] { new Material($"{Gem.GetMaterial(character, "violet")}", 3),  new Material($"{character.Local_specialty}", 30),  new Material($"{character.Mini_boss}", 8) ,  new Material($"{Enemy.GetMaterial(character, "green")}", 18),   new Material("Mora", 80000) } },
                { "70+", new Material[] { new Material($"{Gem.GetMaterial(character, "violet")}", 6),  new Material($"{character.Local_specialty}", 45),  new Material($"{character.Mini_boss}", 12),  new Material($"{Enemy.GetMaterial(character, "blue")}",  12),   new Material("Mora", 100000) } },
                { "80+", new Material[] { new Material($"{Gem.GetMaterial(character, "orange")}", 6),  new Material($"{character.Local_specialty}", 60),  new Material($"{character.Mini_boss}", 20),  new Material($"{Enemy.GetMaterial(character, "blue")}",  24),   new Material("Mora", 120000) } }
            };
        }


        private static readonly List<string> levels = new()  {
            "1"  ,  "2" ,  "3",  "4" , "5" , "6" , "7" , "8" , "9" , "10",
            "11" ,  "12", "13",  "14", "15", "16", "17", "18", "19", "20", "20+",
            "21" ,  "22", "23",  "24", "25", "26", "27", "28", "29", "30",
            "31" ,  "32", "33",  "34", "35", "36", "37", "38", "39", "40", "40+",
            "41" ,  "42", "43",  "44", "45", "46", "47", "48", "49", "50", "50+",
            "51" ,  "52", "53",  "54", "55", "56", "57", "58", "59", "60", "60+",
            "61" ,  "62", "63",  "64", "65", "66", "67", "68", "69", "70", "70+",
            "71" ,  "72", "73",  "74", "75", "76", "77", "78", "79", "80", "80+",
            "81" ,  "82", "83",  "84", "85", "86", "87", "88", "89", "90"
        };
    }
}