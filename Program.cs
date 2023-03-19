using Genshin.src;
using Genshin.src.LevelingResources;
using static System.Console;

namespace Genshin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            Inventory.Import();
            //Character c1 = Inventory.GetNotDeletedCharacters()[0];
            //Character c1 = Inventory.GetDeletedCharacters()[0];
            //Inventory.AddCharacter(c1);
            //Inventory.CharacrerLevelUp(c1, "20+");
            //Inventory.AAChangeLevel(c1, 2);
            //Inventory.ElemChangeLevel(c1, 2);
            //Inventory.BurstChangeLevel(c1, 2);
            //Inventory.TotalCost(c1);
            //Print(Inventory.RequiredMaterials[c1]);
            //Inventory.Upgrade(c1);
            Dictionary<Character, List<Material>> c = Inventory.CalcRequiredMaterials();
            foreach (var k in c.Keys)
            {
                WriteLine(k.Name);
                Print(c[k]);
            }
            Inventory.Export();
            ReadLine();
        }
        public static void Print<T>(List<T> list)
        {
            foreach (var c in list)
                WriteLine(c);
        }
    }
}