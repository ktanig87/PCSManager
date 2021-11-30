using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.Box
{
    public class BoxEdit
    {
        public int BoxId { get; set; }
        [Display(Name = "Box Size")]
        public string BoxSize { get; set; }
        [Display(Name = "Move")]


        public int MoveId { get; set; }
        [Display(Name = "Room")]

        public int RoomId { get; set; }
    }
}
