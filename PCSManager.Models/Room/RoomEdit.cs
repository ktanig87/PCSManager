using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.Room
{
    public class RoomEdit
    {
        [Display(Name = "Move Id")]
        public int MoveId { get; set; }
        [Display(Name = "Room Id")]
        public int RoomId { get; set; }
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }
    }
}
