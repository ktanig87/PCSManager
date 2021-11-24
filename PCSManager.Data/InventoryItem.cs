using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Data
{
    public class InventoryItem
    {
        [Key]
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal ItemValue { get; set; }
        public bool HighValue
        {
            get
            {
                if (ItemValue > 600)
                    return true;
                else
                    return false;
            }
        }
        public string UPC { get; set; }

        public virtual Box Box { get; set; }
        [ForeignKey(nameof(Box))]
        public int? BoxId { get; set; }

        public virtual Room Room { get; set; }
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
    }
}
