using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Data
{
    public class MoveInfo
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string MoverName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int DriverPhone { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int TSPPhone { get; set; }
    }
}
