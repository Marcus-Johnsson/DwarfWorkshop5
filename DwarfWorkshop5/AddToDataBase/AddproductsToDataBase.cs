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
                        RecipeId =1
                    },
                    new Products
                    {
                        Name = "Copper Bar",
                        CategoryId = 2,
                        LvlRequirement = 2,
                        TimeEfficiency = 0.10,
                        RecipeId = 2
                    },
                    new Products
                    {
                        Name = "Cobalt Bar",
                        CategoryId = 2,
                        LvlRequirement = 5,
                        TimeEfficiency = 0.15,
                        RecipeId =3
                    },
                    new Products
                    {
                        Name = "Silver Bar",
                        CategoryId = 2,
                        LvlRequirement = 8,
                        TimeEfficiency = 0.20,
                        RecipeId =4
                    },
                    new Products
                    {
                        Name = "Gold Bar",
                        CategoryId = 2,
                        LvlRequirement = 12,
                        TimeEfficiency = 0.25,
                        RecipeId =5
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
                        Price = 0,
                        
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

        public static void CreateRecipe()
        {
            using (var mydb = new MyDbContext())
            {
                mydb.AddRange(
                new Recipe
                {
                    ProductId = 6,
                    WorkTime = 5,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 1,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 7,
                    WorkTime = 6,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {
                                MaterialId = 2,
                                Quantity = 4
                         }
                    }
                },


                new Recipe
                {
                    ProductId = 8,
                    WorkTime = 7,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 3,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 9,
                    WorkTime = 8,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 4,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 10,
                    WorkTime = 9,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 5,
                            Quantity = 4
                        }
                    }
                },
                new Recipe  // iron ring
                {
                    ProductId = 17,
                    WorkTime = 10,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 6,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 18,
                    WorkTime = 15,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 6,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 19,
                    WorkTime = 13,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 6,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 20,
                    WorkTime = 25,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 21,
                    WorkTime = 20,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 22,
                    WorkTime = 15,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 6,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 23,
                    WorkTime = 20,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 6,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 24,
                    WorkTime = 30,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 25,
                    WorkTime = 120,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 6,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 11,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 26,
                    WorkTime = 240,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 11,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 27,
                    WorkTime = 25,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 28,
                    WorkTime = 80,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 29,
                    WorkTime = 95,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 30,
                    WorkTime = 35,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 31,
                    WorkTime = 350,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 12,
                            Quantity = 12
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 32,
                    WorkTime = 600,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 11,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 33,
                    WorkTime = 120,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 34,
                    WorkTime = 1000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 35,
                    WorkTime = 200,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 36,
                    WorkTime = 380,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 1
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 12,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 37,
                    WorkTime = 2200,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 12,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 38,
                    WorkTime = 3800,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 39,
                    WorkTime = 1000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 40,
                    WorkTime = 3000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 3
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 41,
                    WorkTime = 5500,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 1
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 42,
                    WorkTime = 3800,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 1
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 12,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 43,
                    WorkTime = 4000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 14,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 44,
                    WorkTime = 5800,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 8,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 45,
                    WorkTime = 1800,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 6,
                            Quantity = 20
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 12,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 46,
                    WorkTime = 2200,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 1
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 11,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 47,
                    WorkTime = 5400,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 48,
                    WorkTime = 3000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 3
                        },
                    }
                },
                new Recipe
                {
                    ProductId = 49,
                    WorkTime = 4200,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 11,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 50,
                    WorkTime = 3800,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 51,
                    WorkTime = 6000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity =2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 10,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 52,
                    WorkTime = 6500,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 53,
                    WorkTime = 5000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 7,
                            Quantity = 1
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 54,
                    WorkTime = 8000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 55,
                    WorkTime = 4500,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 4
                        },
                    }
                },
                new Recipe
                {
                    ProductId = 56,
                    WorkTime = 7000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 11,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 57,
                    WorkTime = 4900,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 1
                        },
                    }
                },
                new Recipe
                {
                    ProductId = 58,
                    WorkTime = 9200,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 59,
                    WorkTime = 7500,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 12,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 60,
                    WorkTime = 8500,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 61,
                    WorkTime = 6250,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 14,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 62,
                    WorkTime = 4900,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 8,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 63,
                    WorkTime = 12000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 64,
                    WorkTime = 16000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 65,
                    WorkTime = 10000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 9,
                            Quantity = 1
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 14,
                            Quantity = 1
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 66,
                    WorkTime = 18000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 15,
                            Quantity = 2
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 67,
                    WorkTime = 12000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 4
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 14,
                            Quantity = 3
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 68,
                    WorkTime = 8000,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 2
                        },
                        new Recipe.MaterialRequirement
                        {
                            MaterialId = 13,
                            Quantity = 4
                        }
                    }
                },
                new Recipe
                {
                    ProductId = 69,
                    WorkTime = 2678400,
                    MaterialsRequired =
                    {
                        new Recipe.MaterialRequirement
                        {

                            MaterialId = 10,
                            Quantity = 100
                        },
                    }
                }
                
                );
                mydb.SaveChanges();
            }
        }
    }


}

