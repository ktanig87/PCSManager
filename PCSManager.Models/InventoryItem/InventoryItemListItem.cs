using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.InventoryItem
{
    public class InventoryItemListItem
    {
        [Display(Name = "Inventory Id")]

        public int InventoryId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Box ID")]
        public int BoxId { get; set; }
        [Display(Name = "Room")]
        public int RoomId { get; set; }
    }
}
