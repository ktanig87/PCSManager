using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.Box
{
    public class BoxDetail
    {
        [Display(Name = "Box ID")]
        public int BoxId { get; set; }
        [Display(Name = "Box Size")]
        public string BoxSize { get; set; }


        [Display(Name = "Move")]
        public string Move { get; set; }
        public int MoveId { get; set; }
        public int RoomId { get; set; }
        [Display(Name = "Room")]
        public string RoomName { get; set; }

      
    }
}
