using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.Calculations
{
    class SellPrice
    {
        public static void SellPricePartOne()
        {
            using (var mydb = new MyDbContext())
            {

                var everyProducts = mydb.Products.ToList();

                foreach (var product in everyProducts)
                {
                    if (product.CategoryId == 1 || product.CategoryId == 3)
                    {
                        continue; // ensure that ore/gem price is not changed
                    }
                    double cost = 0;
                    double timeEfficiency = 1;
                    var recipe = mydb.Recipes.FirstOrDefault(p => p.Id == product.RecipeId);

                    if (recipe == null)
                    {
                        continue;
                    }
                    foreach (var material in recipe.MaterialsRequired)
                    {
                        var productId = everyProducts.FirstOrDefault(p => p.RecipeId == recipe.Id);
                        var materialRecipe = mydb.Recipes.Where(p => p.ProductId == productId.Id).FirstOrDefault(); 
                        if (materialRecipe.MaterialsRequired != null) // if not null it has a recipe
                        {
                            var barRecipeId = mydb.Recipes.FirstOrDefault(r => r.Id == productId.RecipeId);

                            if (barRecipeId != null)
                            {
                                var oreMaterial = barRecipeId.MaterialsRequired.FirstOrDefault();
                                
                                if (oreMaterial != null)
                                {
                                    double barPrice = ((material.Quantity * oreMaterial.Quantity) * productId.Price);
                                    timeEfficiency += productId.TimeEfficiency;

                                    cost += barPrice;
                                }
                            }
                        }
                        else
                        {
                            var materialProduct = mydb.Products.FirstOrDefault(p => p.Id == productId.Id);
                            if (materialProduct != null)
                            {
                                double materialCost = (materialProduct.Price * material.Quantity);
                                timeEfficiency += productId.TimeEfficiency;
                                cost += materialCost; 
                            }
                        }
                    }
                    cost *= timeEfficiency;
                product.Price = cost;
                }
            }
        }

        public static void SellPricePartTwo()
        {

            double miniumPriceControll = 0.7;
            double LowsuppleIncrease = 1.2;
            
            using (var mydb = new MyDbContext())
            {
                var everyProduct = mydb.Products.ToList();

                foreach(var product in everyProduct)
                {
                    var shopInfo = mydb.Shop.FirstOrDefault(p => p.ProductId == product.Id);
                    double supplyControll = shopInfo.Supply / shopInfo.Demand;

                    double supDem = Math.Max(miniumPriceControll, (shopInfo.Demand - shopInfo.Supply / 1000));

                    if(supplyControll < 0.2)
                    {
                        supDem *= LowsuppleIncrease;
                    }

                }
            }
        }
    }
}
