using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;

namespace DwarfWorkshop5.Models
{
    class Dwarfs
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public int EffifencyRank { get; set; }

        public int QualityRank { get; set; }

        public List<int>? WorkOrder { get; set; }

        public int Rank { get; set; }


    }    
}
