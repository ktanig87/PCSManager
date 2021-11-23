using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.InventoryItem
{
    public class InventoryItemListItem
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int BoxId { get; set; }
        public int RoomId { get; set; }
    }
}
