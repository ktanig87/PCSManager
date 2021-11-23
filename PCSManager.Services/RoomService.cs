using PCSManager.Data;
using PCSManager.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Services
{
    public class RoomService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public RoomService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRoom(RoomCreate model)
        {
            var entity =
                new Room()
                {
                    RoomName = model.RoomName,
                    MoveId = model.MoveId

                };
            {
                ctx.Rooms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoomListItem> GetRooms()
        {
            var query =
                ctx.Rooms
                .Select(
                    e =>
                    new RoomListItem
                    {
                        RoomId = e.RoomId,
                        RoomName = e.RoomName

                    }
                    );
            return query.ToArray();
        }


        public RoomDetail GetRoombyId(int id)
        {
            var entity =
                ctx.Rooms
                .Single(e => e.RoomId == id);
            return
                new RoomDetail
                {
                    RoomId = entity.RoomId,
                    RoomName = entity.RoomName,
                    MoveId = entity.MoveId
                };

        }


        public bool UpdateRoom(RoomEdit model)
        {
            var entity =
                ctx.Rooms
                .Single(e => e.RoomId == model.RoomId);
            entity.RoomId = model.RoomId;
            entity.RoomName = model.RoomName;
            entity.MoveId = model.MoveId;
            return ctx.SaveChanges() == 1;
        }

        public bool DeleteRoom(int roomId)
        {
            var entity =
                ctx.Rooms
                .Single(e => e.RoomId == roomId);
            ctx.Rooms.Remove(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}

