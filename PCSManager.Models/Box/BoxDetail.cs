using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.Box
{
    public class BoxDetail
    {
        public int BoxId { get; set; }
        public string BoxSize { get; set; }
        public int MoveId { get; set; }
        public int RoomId { get; set; }
    }
}
