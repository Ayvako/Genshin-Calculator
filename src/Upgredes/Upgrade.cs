namespace Genshin.src.Upgredes
{
    public abstract class Upgrade
    {
        protected static void AddMaterialToMap(Dictionary<string, int> d, string material, int amount)
        {
            //if (d.TryGetValue(material, out int existingAmount))
            //{
            //    d[material] = existingAmount + amount;
            //}
            //else
            //{
            //    d.Add(material, amount);
            //}

            d.TryGetValue(material, out int existingAmount);
            d[material] = existingAmount + amount;

        }


    }
}