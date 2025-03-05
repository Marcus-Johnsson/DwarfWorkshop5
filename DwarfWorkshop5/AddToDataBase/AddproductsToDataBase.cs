using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.AddToDataBase
{
    class AddproductsToDataBase
    {
        //Only to save every Products Incase of somethings happens
        //also available every where i go

        // CategoryId ore = 1 | bar = 2 | gem = 3 | finished product = 4 |

        // Finished product Time Effencie | Ring 10% |

        // Hej Micke! Allt här är inte "Med" i koden. Är här så om något händer kan jag börja om eller fortsätta enkelt med att bygga vidare efter uppgiften.
        public static void AddProductsToDataBase()
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
                        TimeEfficiency = 0.05,
                    },
                    new Products
                    {
                        Name = "Copper Ore",
                        CategoryId = 1,
                        LvlRequirement = 2,
                        TimeEfficiency = 0.05,

                    },
                    new Products
                    {
                        Name = "Cobalt Ore",
                        CategoryId = 1,
                        LvlRequirement = 5,
                        TimeEfficiency = 0.05,

                    },
                    new Products
                    {
                        Name = "Silver Ore",
                        CategoryId = 1,
                        LvlRequirement = 8,
                        TimeEfficiency = 0.05,

                    },
                    new Products
                    {
                        Name = "Gold Ore",
                        CategoryId = 1,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.05,

                    },
                    new Products
                    {
                        Name = "Iron Bar",
                        CategoryId = 2,
                        LvlRequirement = 1,
                        TimeEfficiency = 0.05,

                    },
                    new Products
                    {
                        Name = "Copper Bar",
                        CategoryId = 2,
                        LvlRequirement = 2,
                        TimeEfficiency = 0.10,

                    },
                    new Products
                    {
                        Name = "Cobalt Bar",
                        CategoryId = 2,
                        LvlRequirement = 5,
                        TimeEfficiency = 0.15,

                    },
                    new Products
                    {
                        Name = "Silver Bar",
                        CategoryId = 2,
                        LvlRequirement = 8,
                        TimeEfficiency = 0.20,

                    },
                    new Products
                    {
                        Name = "Gold Bar",
                        CategoryId = 2,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.25,

                    },
                    new Products
                    {
                        Name = "Aquamarine",
                        CategoryId = 3,
                        LvlRequirement = 3,
                        TimeEfficiency = 0.10,
                        Price = 5500
                    },
                    new Products
                    {
                        Name = "Emerald",
                        CategoryId = 3,
                        LvlRequirement = 6,
                        TimeEfficiency = 0.20,
                        Price = 10000
                    },
                    new Products
                    {
                        Name = "Ruby",
                        CategoryId = 3,
                        LvlRequirement = 9,
                        TimeEfficiency = 0.30,
                        Price = 15000
                    },
                    new Products
                    {
                        Name = "Tsavorite",
                        CategoryId = 3,
                        LvlRequirement = 11,
                        TimeEfficiency = 0.50,
                        Price = 25000
                    },
                    new Products
                    {
                        Name = "Tanzanite",
                        CategoryId = 3,
                        LvlRequirement = 13,
                        TimeEfficiency = 0.75,
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
                    new Products
                    {
                        Name = "Iron Ring",
                        CategoryId = 4,
                        LvlRequirement = 1,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Iron Chain",
                        CategoryId = 4,
                        LvlRequirement = 1,
                        TimeEfficiency = 0.1,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Iron Necklace",
                        CategoryId = 4,
                        LvlRequirement = 2,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Ring",
                        CategoryId = 4,
                        LvlRequirement = 2,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Chain",
                        CategoryId = 4,
                        LvlRequirement = 2,
                        TimeEfficiency = 0.1,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Iron EarPiece",
                        CategoryId = 4,
                        LvlRequirement = 3,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Iron Bracelet",
                        CategoryId = 4,
                        LvlRequirement = 3,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Bracelet",
                        CategoryId = 4,
                        LvlRequirement = 3,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Iron Ring with Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 4,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Ring with Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 4,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Necklace",
                        CategoryId = 4,
                        LvlRequirement = 4,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Chain",
                        CategoryId = 4,
                        LvlRequirement = 5,
                        TimeEfficiency = 0.10,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Ring",
                        CategoryId = 4,
                        LvlRequirement = 5,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Earpiece",
                        CategoryId = 4,
                        LvlRequirement = 5,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Bracelet With Emerald",
                        CategoryId = 4,
                        LvlRequirement = 6,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Ring With Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 6,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Bracelet",
                        CategoryId = 4,
                        LvlRequirement = 6,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Chain",
                        CategoryId = 4,
                        LvlRequirement = 7,
                        TimeEfficiency = 0.10,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Ring",
                        CategoryId = 4,
                        LvlRequirement = 7,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Earpiece With Emerald",
                        CategoryId = 4,
                        LvlRequirement = 7,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Bracelet With Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 8,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Earpiece With Ruby",
                        CategoryId = 4,
                        LvlRequirement = 8,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Bracelet",
                        CategoryId = 4,
                        LvlRequirement = 9,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Necklace With Ruby",
                        CategoryId = 4,
                        LvlRequirement = 9,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Earpiece With Ruby",
                        CategoryId = 4,
                        LvlRequirement = 10,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Earpiece With Emerald",
                        CategoryId = 4,
                        LvlRequirement = 10,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Braclet With Tsavorite",
                        CategoryId = 4,
                        LvlRequirement = 10,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Ring With Tsavorite",
                        CategoryId = 4,
                        LvlRequirement = 10,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Iron Elephant With Emeralds",
                        CategoryId = 4,
                        LvlRequirement = 11,
                        TimeEfficiency = 0.50,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Earpiece With Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 11,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Necklace With Ruby",
                        CategoryId = 4,
                        LvlRequirement = 11,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Chain",
                        CategoryId = 4,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.10,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Necklace With Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Ring",
                        CategoryId = 4,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Ring With Tsavorite",
                        CategoryId = 4,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Ring With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Copper Earpiece With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 13,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Ring With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 13,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Bracelet",
                        CategoryId = 4,
                        LvlRequirement = 13,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Bracelet With Aquamarine",
                        CategoryId = 4,
                        LvlRequirement = 14,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Earpiece",
                        CategoryId = 4,
                        LvlRequirement = 14,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Bracelet With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 14,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Necklace With Emerald",
                        CategoryId = 4,
                        LvlRequirement = 14,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Ring With Ruby",
                        CategoryId = 4,
                        LvlRequirement = 14,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Necklace With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 14,
                        TimeEfficiency = 0.17,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Cobalt Bracelet With Ruby",
                        CategoryId = 4,
                        LvlRequirement = 15,
                        TimeEfficiency = 0.12,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Ring With Diamond",
                        CategoryId = 4,
                        LvlRequirement = 15,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Bracelet With Diamond",
                        CategoryId = 4,
                        LvlRequirement = 15,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Silver Earpiece With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 15,
                        TimeEfficiency = 0.20,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Necklace With Diamond",
                        CategoryId = 4,
                        LvlRequirement = 16,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Bracelet With Tanzanite",
                        CategoryId = 4,
                        LvlRequirement = 16,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "Gold Ring With Tsavorite",
                        CategoryId = 4,
                        LvlRequirement = 16,
                        TimeEfficiency = 0.15,
                        Price = 0
                    },
                    new Products
                    {
                        Name = "The One Ring",
                        CategoryId = 4,
                        LvlRequirement = 20,
                        TimeEfficiency = 10,
                        Price = 0
                    }
                    );
                mydb.SaveChanges();
            }
        }

        //public static void CreateRecipe()
        //{
        //    using (var mydb = new MyDbContext())
        //    {
        //        var ironBarReq = new Recipe.MaterialRequirement
        //        {
        //            ProductId = ,
        //            Material = ,
        //            Quantity = 4
        //        };
        //    }
        //}


    }
}
