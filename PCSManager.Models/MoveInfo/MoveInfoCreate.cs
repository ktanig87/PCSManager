using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.MoveInfo
{
    public class MoveInfoCreate
    {
        [Display(Name = "Mover Name")]
        public string MoverName { get; set; }
        [Display(Name = "Driver Phone #")]
        public int DriverPhone { get; set; }
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; }
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "TSP Phone#")]
        public int TSPPhone { get; set; }
    }
}
