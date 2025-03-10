using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwarfWorkshop5.Models
{
    class WorkOrder
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int DwarfId { get; set; }

        public int ProductId { get; set; }

        public int Progress { get; set; }
    }
}
