using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public virtual MoveInfo MoveDetails { get; set; }
        [ForeignKey(nameof(MoveDetails))]
        public int MoveId { get; set; }
    }
}
