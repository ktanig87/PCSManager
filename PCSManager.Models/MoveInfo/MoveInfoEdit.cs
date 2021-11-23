using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.MoveInfo
{
    public class MoveInfoEdit
    {
        public int Id { get; set; }
        public string MoverName { get; set; }
        public int DriverPhone { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TSPPhone { get; set; }
    }
}
