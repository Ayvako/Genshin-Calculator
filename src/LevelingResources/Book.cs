namespace Genshin.src.LevelingResources
{
    public static class Book
    {
        private static readonly Dictionary<string, string[]> Materials_by_book = new()
        {
                {"Freedom",    new[]{ "TeachingsOfFreedom"    ,"GuideToFreedom"    ,"PhilosophiesOfFreedom"   }},
                {"Resistance", new[]{ "TeachingsOfResistance" ,"GuideToResistance" ,"PhilosophiesOfResistance"}},
                {"Ballad",     new[]{ "TeachingsOfBallad"     ,"GuideToBallad"     ,"PhilosophiesOfBallad"    }},
                {"Prosperity", new[]{ "TeachingsOfProsperity" ,"GuideToProsperity" ,"PhilosophiesOfProsperity"}},
                {"Diligence",  new[]{ "TeachingsOfDiligence"  ,"GuideToDiligence"  ,"PhilosophiesOfDiligence" }},
                {"Gold",       new[]{ "TeachingsOfGold"       ,"GuideToGold"       ,"PhilosophiesOfGold"      }},
                {"Transience", new[]{ "TeachingsOfTransience" ,"GuideToTransience" ,"PhilosophiesOfTransience"}},
                {"Elegance",   new[]{ "TeachingsOfElegance"   ,"GuideToElegance"   ,"PhilosophiesOfElegance"  }},
                {"Light",      new[]{ "TeachingsOfLight"      ,"GuideToLight"      ,"PhilosophiesOfLight"     }},
                {"Praxis",     new[]{ "TeachingsOfPraxis"     , "GuideToPraxis"    ,"PhilosophiesOfPraxis"    }},
                {"Admonition", new[]{ "TeachingsOfAdmonition" , "GuideToAdmonition","PhilosophiesOfAdmonition"}},
                //Новые книги!
                //перенести в файл
        };

        public static string GetMaterial(Character character, string rarity) => rarity switch
        {
            "green" => Materials_by_book[character.Book_type][0],
            "blue" => Materials_by_book[character.Book_type][1],
            "violet" => Materials_by_book[character.Book_type][2],
            _ => throw new Exception("Unknown Property Name"),
        };
    }
}
