﻿using Genshin.src.LevelingResources;
using System.Linq;

namespace Genshin.src.Upgrades
{
    public class SkillUpgrade
    {
        public static List<Material> GetCost(Character character, int from, int to)
        {
            var materials = Enumerable.Range(from + 1, to - from).SelectMany(i => GetMaterials(character)[i]);

            var groupedMaterials = materials.GroupBy(m => m.Name).Select(g => new Material(g.Key, g.First().Type, g.Sum(m => m.Amount))).ToList();



            return groupedMaterials;
        }

        private static Dictionary<int, Material[]> GetMaterials(Character сharacter)
        {
            return new(){
                {2,new Material[]{ new($"{Book.GetMaterial(сharacter,"green")}", MaterailTypes.BOOK,3), new ($"{Enemy.GetMaterial(сharacter, "white")}", MaterailTypes.ENEMY, 6), new ("Mora", MaterailTypes.OTHER, 12500) } },

                {3,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", MaterailTypes.BOOK, 2),  new ($"{Enemy.GetMaterial(сharacter, "green")}", MaterailTypes.ENEMY, 3), new ("Mora", MaterailTypes.OTHER, 17500) } },
                {4,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", MaterailTypes.BOOK, 4),  new ($"{Enemy.GetMaterial(сharacter, "green")}", MaterailTypes.ENEMY, 4), new ("Mora", MaterailTypes.OTHER, 25000) } },
                {5,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", MaterailTypes.BOOK, 6),  new ($"{Enemy.GetMaterial(сharacter, "green")}", MaterailTypes.ENEMY, 6), new ("Mora", MaterailTypes.OTHER, 30000) } },
                {6,new Material[]{ new ($"{Book.GetMaterial(сharacter, "blue")}", MaterailTypes.BOOK, 9),  new ($"{Enemy.GetMaterial(сharacter, "green")}", MaterailTypes.ENEMY, 9), new ("Mora", MaterailTypes.OTHER, 37500) } },

                {7,new Material[]{ new ($"{Book.GetMaterial(сharacter, "violet")}", MaterailTypes.BOOK, 4),   new ($"{Enemy.GetMaterial(сharacter, "blue")}", MaterailTypes.ENEMY, 4), new ($"{сharacter.Assets.WeeklyBoss}", MaterailTypes.OTHER, 1), new ("Mora", MaterailTypes.OTHER, 120000) } },
                {8,new Material[]{ new ($"{Book.GetMaterial(сharacter, "violet")}", MaterailTypes.BOOK, 6),   new ($"{Enemy.GetMaterial(сharacter, "blue")}", MaterailTypes.ENEMY, 6), new ($"{сharacter.Assets.WeeklyBoss}", MaterailTypes.OTHER, 1), new ("Mora", MaterailTypes.OTHER, 260000) } },
                {9,new Material[]{ new ($"{Book.GetMaterial(сharacter, "violet")}", MaterailTypes.BOOK, 12),  new ($"{Enemy.GetMaterial(сharacter, "blue")}", MaterailTypes.ENEMY, 9), new ($"{сharacter.Assets.WeeklyBoss}", MaterailTypes.OTHER, 2), new ("Mora", MaterailTypes.OTHER, 450000) } },
                {10,new Material[]{new ($"{Book.GetMaterial(сharacter, "violet")}", MaterailTypes.BOOK, 16),  new ($"{Enemy.GetMaterial(сharacter, "blue")}", MaterailTypes.ENEMY, 12),new ($"{сharacter.Assets.WeeklyBoss}", MaterailTypes.OTHER, 2), new ("Mora", MaterailTypes.OTHER, 700000) , new ("CrownOfInsight", MaterailTypes.OTHER, 1) } },
            };
        }
    }
}