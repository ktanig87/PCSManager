using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.InventoryItem
{
    public class InventoryItemCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        [Display(Name = "Value")]
        public decimal ItemValue { get; set; }
        [Display(Name = "High Value?")]
        public bool HighValue { get; set; }
        public string UPC { get; set; }
        [Display(Name = "Box ID")]
        public int BoxId { get; set; }
        [Display(Name = "Room")]
        public int RoomId { get; set; }
    }
}
