using Genshin.src.LevelingResources;

namespace Genshin.src.Upgredes
{
    public class SkillUpgrade : Upgrade
    {
        public static Dictionary<string, int> GetCost(Character character, int from, int to)
        {
            //Dictionary<string, int> Amount_of_materials_to_levelup = new();
            //Dictionary<int, Material[]> Number_of_materials_for_levels = GetMaterialsForCharacter(character);
            //
            //for (int i = from + 1; i <= to; i++)
            //{
            //    foreach (var v in Number_of_materials_for_levels[i])
            //        AddMaterialToMap(Amount_of_materials_to_levelup, v.Name, v.Amount);
            //}
            //return Amount_of_materials_to_levelup;
            var materials = Enumerable.Range(from + 1, to - from).SelectMany(i => GetMaterialsForCharacter(character)[i]);
            return materials.GroupBy(m => m.Name).ToDictionary(g => g.Key, g => g.Sum(m => m.Amount));
        }

        private static Dictionary<int, Material[]> GetMaterialsForCharacter(Character сharacter)
        {
            return new(){
                {2,new Material[]{ new($"{Book.GetMaterial(сharacter,"green")}", 3), new ($"{Enemy.GetMaterial(сharacter, "white")}", 6), new ("Mora",12500) } },

                {3,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", 2),  new ($"{Enemy.GetMaterial(сharacter, "green")}", 3), new ("Mora", 17500) } },
                {4,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", 4),  new ($"{Enemy.GetMaterial(сharacter, "green")}", 4), new ("Mora", 25000) } },
                {5,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", 6),  new ($"{Enemy.GetMaterial(сharacter, "green")}", 6), new ("Mora", 30000) } },
                {6,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", 9),  new ($"{Enemy.GetMaterial(сharacter, "green")}", 9), new ("Mora", 37500) } },

                {7,new Material[]{ new ($"{Book.GetMaterial(сharacter, "violet")}", 4),   new ($"{Enemy.GetMaterial(сharacter, "blue")}", 4), new ($"{сharacter.Weekly_boss}", 1), new ("Mora", 120000) } },
                {8,new Material[]{ new ($"{Book.GetMaterial(сharacter, "violet")}", 6),   new ($"{Enemy.GetMaterial(сharacter, "blue")}", 6), new ($"{сharacter.Weekly_boss}", 1), new ("Mora", 260000) } },
                {9,new Material[]{ new ($"{Book.GetMaterial(сharacter, "violet")}", 12),  new ($"{Enemy.GetMaterial(сharacter, "blue")}", 9), new ($"{сharacter.Weekly_boss}", 2), new ("Mora", 450000) } },
                {10,new Material[]{new ($"{Book.GetMaterial(сharacter, "violet")}", 16),  new ($"{Enemy.GetMaterial(сharacter, "blue")}", 12),new ($"{сharacter.Weekly_boss}", 2), new ("Mora", 700000) , new ("CrownOfInsight", 1) } },
            };
        }
    }
}