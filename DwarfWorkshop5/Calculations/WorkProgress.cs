using DwarfWorkhop5;
using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.Calculations
{
    class WorkProgress
    {
        public void CalculateWorkProgress(double runTime)
        {
            using (var mydb = new MyDbContext())
            {
                Random rng = new Random();
                for (int i = 0; i < runTime; i++)
                {


                    try
                    {
                        var everyOrder = mydb.WorkOrder.Where(p => p.Progress < 100 && p.UserId == GetSetData.GetCurrentUser().Id && p.Active == true).ToList();
                        var groupedOrders = everyOrder
                                    .GroupBy(order => new
                                    { order.UserId, order.ProductId })
                                    .ToList();

                        foreach (var group in groupedOrders) // group users specific Product
                        {
                            double totalWorkSpeed = 0;


                            var productId = group.Key.ProductId;
                            var user = mydb.User.Where(p => p.Id == group.Key.UserId).SingleOrDefault();

                            foreach (var orderInGroup in group) // Every order an user have
                            {
                                foreach (var dwarfId in orderInGroup.DwarfId) // Iterate through Dwarf IDs
                                {
                                    var dwarf = mydb.Dwarfs.SingleOrDefault(p => p.Id == dwarfId);
                                    if (dwarf != null)
                                    {
                                        totalWorkSpeed += CalculateEfficiencyMultiplier(dwarf.EffifencyRank, user.TokenAmount);
                                    }
                                }
                            }

                            var recipe = mydb.Recipes.FirstOrDefault(p => p.ProductId == productId);
                            if (recipe == null) continue;

                            double ProcentWorkTime = totalWorkSpeed / recipe.WorkTime;

                            var workOrder = group.First();

                            if (workOrder.Progress < 100)
                            {
                                double completetWork = Math.Max(50, ProcentWorkTime * 100);

                                workOrder.Progress = Math.Min(100, workOrder.Progress + (int)completetWork);
                            }
                            if (workOrder.Progress == 100)
                            {
                                bool quality = false;
                                var product = mydb.Products.Where(p => p.Id == workOrder.Id).SingleOrDefault();

                                if (product.CategoryId == 4) // No materials, only A finished Product
                                {
                                    foreach (var workers in group)
                                    {
                                        var dwarf = mydb.Dwarfs.Where(p => p.Id == workers.Id).SingleOrDefault();

                                        double qualityChance = CalculateQualityChance(dwarf.QualityRank, dwarf.Rank);


                                        int main = rng.Next(0, 100);
                                        int hundreds = rng.Next(1, 99);

                                        float procentToQuality = main + (hundreds / 100);

                                        if (procentToQuality <= qualityChance)
                                        {
                                            quality = true;
                                        }
                                    }
                                }

                                AddToInventory(productId, quality);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        public void AddToInventory(int workOrder, bool quality)
        {
            using (var mydb = new MyDbContext())
            {
                try
                {
                    var currentUser = GetSetData.GetCurrentUser();

                    var inventory = mydb.Inventory.Where(p => p.UserId == currentUser.Id && p.ProductId == workOrder && p.Quality == quality).FirstOrDefault();

                    var product = mydb.Products.Where(p => p.Id == workOrder).SingleOrDefault();


                    if (product.Id == inventory.ProductId && inventory.Quality == quality)
                    {
                        inventory.Quantity++;
                        mydb.SaveChanges();
                    }
                    else
                    {
                        mydb.Inventory.Add
                        (
                        new Inventory
                        {
                            ProductId = product.Id,
                            Quality = quality,
                            Quantity = 1,
                            UserId = currentUser.Id,
                        }
                        );
                        mydb.SaveChanges();
                    }
                }
                catch
                {

                }
            }


        }


        public double CalculateEfficiencyMultiplier(int efficiencyRank, int rank)
        {
            double efficiencyMultiplier = 1 * (1 + 0.05 * efficiencyRank) * (1 + 0.05 * rank);

            return Math.Round(efficiencyMultiplier, 1);
        }
        public double CalculateTime()
        {
            using (var mydb = new MyDbContext())
            {
                var lastSave = mydb.User.Where(p => p.Id == GetSetData.GetCurrentUser().Id).FirstOrDefault();

                DateTime endTime = DateTime.UtcNow;

                TimeSpan difference = lastSave.LastSave - endTime;
                double secondsElapsed = difference.TotalSeconds;
                lastSave.LastSave = DateTime.UtcNow;
                return secondsElapsed;
            }
        }
        public double CalculateQualityChance(int qualityChance, int Token)
        {
            double QualityChance = 0.01 + (qualityChance * 0.00025 * (1 + 0.05 * Token));

            return Math.Round(QualityChance, 2);
        }

        public bool RemoveMaterialForRecipe(int recipeId, int dwarfId)
        {
            using (var mydb = new MyDbContext())
            {
                var recipe = mydb.Recipes.Where
                                    (p => p.Id == recipeId).FirstOrDefault();

                if (recipe == null) { return false; }
                var userId = GetSetData.GetCurrentUser();


                var inventory = mydb.Inventory.Where(p => p.UserId == userId.Id).ToDictionary(p => p.ProductId, p => p);
                foreach (var requiredMaterial in recipe.MaterialsRequired)
                {
                    if (!inventory.TryGetValue(requiredMaterial.MaterialId, out var inventoryItem) || inventoryItem.Quantity < requiredMaterial.Quantity) // Using a linq to get inventoryItem aswell as controll quantity. Super!!
                    {
                        return false;
                    }
                }
                {
                    try
                    {
                        foreach (var requiredMaterial in recipe.MaterialsRequired)
                        {
                            var inventoryItem = inventory[requiredMaterial.MaterialId];
                            inventoryItem.Quantity -= requiredMaterial.Quantity;
                        }
                        mydb.WorkOrder.Add(new WorkOrder
                        {
                            ProductId = recipe.ProductId,
                            Active = true,
                            Progress = 0,
                            UserId = userId.Id,
                            DwarfId = { dwarfId }
                        });
                        mydb.SaveChanges();
                        return true;
                    }
                    catch (Exception ex) { return false; }

                }

            }
        }
    }
}

