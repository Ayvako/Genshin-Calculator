using Genshin.src.LevelingResources;
using static System.Console;

namespace Genshin.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            Inventory.Import();


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