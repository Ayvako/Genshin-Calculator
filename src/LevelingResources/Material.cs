namespace Genshin.src.LevelingResources
{
    public class Material
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public Material(string name, int amount = 0)
        {
            Name = name;
            Amount = amount;
        }
        public override bool Equals(object? obj)
        {
            var item = obj as Material;
            if (item == null)
            {
                return false;
            }

            return Name.Equals(item.Name);

        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"Material: {Name,-25} Amount: {Amount}";
        }

    }
}
