using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DwarfWorkshop5.Models
{
    class Shop
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Supply { get; set; }

        public int Demand { get; set; }

        private double DemandReduceRate = 0.2;


        public Shop()
        {
           
        }

        public static void AdjustSupply()
        {
            
            using(var MyDb = new MyDbContext())
            {
                var everyProduct = MyDb.Shop.ToList();

                foreach(var product in everyProduct)
                {
                    int reduction = (int)(product.Demand * product.DemandReduceRate);

                    int newSupply = Math.Max(0, product.Supply - reduction);
                }
                MyDb.SaveChanges();
            }
        }

        
    }
}
