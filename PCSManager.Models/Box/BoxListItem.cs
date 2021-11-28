using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.Box
{
    public class BoxListItem
    {
        [Display(Name = "Box Id")]

        public int BoxId { get; set; }
        [Display(Name = "Room Id")]
        public int RoomId { get; set; }

        public string RoomName { get; set; }
    }
}
