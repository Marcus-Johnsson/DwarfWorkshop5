using DwarfWorkhop5;
using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.AddToDataBase
{
    class Workers
    {
        public static void CreateWorker()
        {
            using (var mydb = new MyDbContext())
            {
                var numberOfDwarfs = mydb.Dwarfs.Where(p => p.UserId == GetSetData.GetCurrentUser()).ToList();
                if (numberOfDwarfs.Count >= 5)
                {
                    // Safty net
                }
                else
                {
                    var dwarf = new Dwarfs()
                    {
                        UserId = GetSetData.GetCurrentUser(),
                        QualityRank = 1,
                        EffifencyRank = 1,
                        Rank = 1,
                        Name = "Dwarf Smith"
                    }
                        ;
                    mydb.AddRange(dwarf);
                    mydb.SaveChanges();
                }
            }
        }
    }
}
