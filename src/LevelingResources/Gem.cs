namespace Genshin.src.LevelingResources
{
    public static class Gem
    {

        private static readonly Dictionary<string, string[]> Materials_by_element = new()
        {
                {Element.CRYO,    new[]{"ShivadaJadeSliver"     ,"ShivadaJadeFragment"      ,"ShivadaJadeChunk"     ,"ShivadaJadeGemstone"      }},
                {Element.ELECTRO, new[]{"VajradaAmethystSliver" ,"VajradaAmethystFragment"  ,"VajradaAmethystChunk" ,"VajradaAmethystGemstone"  }},
                {Element.DENDRO,  new[]{"NagadusEmeraldSliver"  ,"NagadusEmeraldFragment"   ,"NagadusEmeraldChunk"  ,"NagadusEmeraldGemstone"   }},
                {Element.PYRO,    new[]{"AgnidusAgateSliver"    ,"AgnidusAgateFragment"     ,"AgnidusAgateChunk"    ,"AgnidusAgateGemstone"     }},
                {Element.GEO,     new[]{"PrithivaTopazSliver"   ,"PrithivaTopazFragment"    ,"PrithivaTopazChunk"   ,"PrithivaTopazGemstone"    }},
                {Element.HYDRO,   new[]{"VarunadaLazuriteSliver","VarunadaLazuriteFragment" ,"VarunadaLazuriteChunk","VarunadaLazuriteGemstone" }},
                {Element.ANEMO,   new[]{"VayudaTurquoiseSliver" ,"VayudaTurquoiseFragment"  ,"VayudaTurquoiseChunk" ,"VayudaTurquoiseGemstone"  }},
        };

        public static string GetMaterial(Character character, string rarity) => rarity switch
        {
            "green" => Materials_by_element[character.Element][0],
            "blue" => Materials_by_element[character.Element][1],
            "violet" => Materials_by_element[character.Element][2],
            "orange" => Materials_by_element[character.Element][3],
            _ => throw new Exception("Unknown Property Name"),
        };
    }
}