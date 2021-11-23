using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.InventoryItem
{
    public class InventoryItemEdit
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal ItemValue { get; set; }
        public string UPC { get; set; }
        public int BoxId { get; set; }
        public int RoomId { get; set; }
    }
}
