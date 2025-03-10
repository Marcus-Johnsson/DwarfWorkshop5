namespace DwarfWorkshop5.Models
{
    class Recipe
    {

        public int Id { get; set; }
        public int ProductId { get; set; }

        public double WorkTime { get; set; }


        public ICollection<MaterialRequirement> MaterialsRequired { get; set; } = new List<MaterialRequirement>();

        public class MaterialRequirement
        {
            public int Id { get; set; }
            public int MaterialId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
