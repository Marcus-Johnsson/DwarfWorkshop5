using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;

namespace DwarfWorkshop5.Models
{
    public class Dwarfs
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public int EffifencyRank { get; set; }

        public int QualityRank { get; set; }

        public List<int>? RecipeChoices { get; set; }

        public int Rank { get; set; }

        public bool Unlocked { get; set; }




    }    
}
