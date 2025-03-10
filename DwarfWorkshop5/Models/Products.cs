namespace DwarfWorkshop5.Models
{
    class Products
    {
        public int Id { get; set; }

        public int? RecipeId { get; set; } // only recipe to craft the item

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public double TimeEfficiency { get; set; } // iron 5% copper 10% cobalt 15%  silver 20% gold 25% three material item gain 5% extra. Smelting into bars is only 5%.

        public double Price { get; set; }

        public int LvlRequirement { get; set; }

        public List<Products> ProductsMadeFrom { get; set; }




    }
}