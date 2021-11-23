using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Data
{
    public class Box
    {
        [Key]
        public int BoxId { get; set; }
        public string BoxSize { get; set; }

        public virtual Room Room { get; set; }
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
    }
}
