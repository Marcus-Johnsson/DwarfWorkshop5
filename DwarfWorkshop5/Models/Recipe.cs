namespace DwarfWorkshop5.Models
{
    class Recipe
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; } // can remove?

        public double WorkTime { get; set; }


        public List<MaterialRequirement> MaterialsRequired { get; set; } 


        public class MaterialRequirement
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public Products Material { get; set; }
            public int Quantity { get; set; }
        }
    }
}
