namespace Genshin.src.LevelingResources
{
    public static class Enemy
    {
        private static readonly Dictionary<string, string[]> Materials_by_enemy = new()
        {
                {"OldHandguard"             ,new[]  { "OldHandguard"            ,"KageuchiHandguard"   ,"FamedHandguard"      }},
                {"DamagedMask"              ,new[]  { "DamagedMask"             ,"StainedMask"         ,"OminousMask"         }},
                {"SlimeCondensate"          ,new[]  { "SlimeCondensate"         ,"SlimeSecretions"     ,"SlimeConcentrate"    }},
                {"DiviningScroll"           ,new[]  { "DiviningScroll"          ,"SealedScroll"        ,"ForbiddenCurseScroll"}},
                {"TreasureHoarderInsignia"  ,new[]  { "TreasureHoarderInsignia" ,"SilverRavenInsignia" ,"GoldenRavenInsignia" }},
                {"RecruitsInsignia"         ,new[]  { "RecruitsInsignia"        ,"SergeantsInsignia"   ,"LieutenantsInsignia" }},
                {"FirmArrowhead"            ,new[]  { "FirmArrowhead"           ,"SharpArrowhead"      ,"WeatheredAroowhead"  }},
                {"WhopperflowerNectar"      ,new[]  { "WhopperflowerNectar"     ,"ShimmeringNectar"    ,"EnergyNectar"        }},
                {"SpectralHusk"             ,new[]  { "SpectralHusk"            ,"SpectralHeart"       ,"SpectralNucleus"     }},
                {"FadedRedSatin"            ,new[]  { "FadedRedSatin"           ,"TrimmedRedSilk"      ,"RichredBrocade"      }},
                {"FungalSpores"             ,new[]  { "FungalSpores"            ,"LuminescentPollen"   ,"CrystallineCystDust" }}
            //Новые враги!
            //перенести в файл
        };

        public static string GetMaterial(Character character, string rarity) => rarity switch
        {
            "white" => Materials_by_enemy[character.Enemy][0],
            "green" => Materials_by_enemy[character.Enemy][1],
            "blue" => Materials_by_enemy[character.Enemy][2],
            _ => throw new Exception("Unknown Property Name"),
        };
    }
}