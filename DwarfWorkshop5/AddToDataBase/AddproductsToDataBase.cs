using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.AddToDataBase
{
    class AddproductsToDataBase
    {
        //Only to save every Products Incase of somethings happens
        //also available every where i go

        // CategoryId ore = 1 | bar = 2 | gem = 3 | finished product = 4 |
        public static void AddThingsToDataBase()
        {
            using (var mydb = new MyDbContext())
            {
                mydb.AddRange
                    (
                    new Products
                    {
                        Name = "Iron Ore",
                        CategoryId = 1,
                        LvlRequirement = 1,
                        TimeEfficiency = 1.05,
                    },
                    new Products
                    {
                        Name = "Copper Ore",
                        CategoryId = 1,
                        LvlRequirement = 2,
                        TimeEfficiency = 1.05,

                    },
                    new Products
                    {
                        Name = "Cobalt Ore",
                        CategoryId = 1,
                        LvlRequirement = 5,
                        TimeEfficiency = 1.05,

                    },
                    new Products
                    {
                        Name = "Silver Ore",
                        CategoryId = 1,
                        LvlRequirement = 8,
                        TimeEfficiency = 1.05,

                    },
                    new Products
                    {
                        Name = "Gold Ore",
                        CategoryId = 1,
                        LvlRequirement = 12,
                        TimeEfficiency = 1.05,

                    },
                    new Products
                    {
                        Name = "Iron Bar",
                        CategoryId = 2,
                        LvlRequirement = 1,
                        TimeEfficiency = 1.05,

                    },
                    new Products
                    {
                        Name = "Copper Bar",
                        CategoryId = 2,
                        LvlRequirement = 2,
                        TimeEfficiency = 1.10,

                    },
                    new Products
                    {
                        Name = "Cobalt Bar",
                        CategoryId = 2,
                        LvlRequirement = 5,
                        TimeEfficiency = 1.15,

                    },
                    new Products
                    {
                        Name = "Silver Bar",
                        CategoryId = 2,
                        LvlRequirement = 8,
                        TimeEfficiency = 1.20,

                    },
                    new Products
                    {
                        Name = "Gold Bar",
                        CategoryId = 2,
                        LvlRequirement = 12,
                        TimeEfficiency = 1.25,

                    },
                    new Products
                    {
                        Name = "Aquamarine",
                        CategoryId = 3,
                        LvlRequirement = 3,
                        TimeEfficiency = 1.10,
                        Price = 5500
                    },
                    new Products
                    {
                        Name = "Emerald",
                        CategoryId = 3,
                        LvlRequirement = 6,
                        TimeEfficiency = 1.20,
                        Price = 10000
                    },
                    new Products
                    {
                        Name = "Ruby",
                        CategoryId = 3,
                        LvlRequirement = 9,
                        TimeEfficiency = 1.30,
                        Price = 15000
                    },
                    new Products
                    {
                        Name = "Tsavorite",
                        CategoryId = 3,
                        LvlRequirement = 11,
                        TimeEfficiency = 1.50,
                        Price = 25000
                    },
                    new Products
                    {
                        Name = "Tanzanite",
                        CategoryId = 3,
                        LvlRequirement = 13,
                        TimeEfficiency = 1.75,
                        Price = 50000
                    },
                    new Products
                    {
                        Name = "Diamond",
                        CategoryId = 3,
                        LvlRequirement = 15,
                        TimeEfficiency = 2,
                        Price = 100000
                    },



                    );
            }
        }

    }
}
