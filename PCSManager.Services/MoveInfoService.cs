using PCSManager.Data;
using PCSManager.Models.MoveInfo;
using PCSManager.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Services
{
    public class MoveInfoService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public MoveInfoService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMove(MoveInfoCreate model)
        {
            var entity =
                new MoveInfo()
                {
                    OwnerId = _userId,
                    MoverName = model.MoverName,
                    DriverPhone = model.DriverPhone,
                    PickupDate = model.PickupDate,
                    DeliveryDate = model.DeliveryDate,
                    TSPPhone = model.TSPPhone
                };

            {
                ctx.Moves.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MoveInfoListItem> GetMoves()
        {

            {
                var query =
                    ctx.Moves.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new MoveInfoListItem
                        {
                            Id = e.Id,
                            MoverName = e.MoverName
                        }
                        );
                return query.ToArray();
            }
        }

        public MoveInfoDetail GetMovebyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Moves
                    .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                    new MoveInfoDetail
                    {
                        Id = entity.Id,
                        MoverName = entity.MoverName,
                        DriverPhone = entity.DriverPhone,
                        PickupDate = entity.PickupDate,
                        DeliveryDate = entity.DeliveryDate,
                        TSPPhone = entity.TSPPhone
                    };

            }

        }

        public bool UpdateMove(MoveInfoEdit model)
        {

            {
                var entity =
                    ctx.Moves
                    .Single(e => e.Id == model.Id && e.OwnerId == _userId);
                entity.MoverName = model.MoverName;
                entity.DriverPhone = model.DriverPhone;
                entity.PickupDate = model.PickupDate;
                entity.DeliveryDate = model.DeliveryDate;
                entity.TSPPhone = model.TSPPhone;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMove(int moveId)
        {
            var entity =
                ctx.Moves
                .Single(e => e.Id == moveId && e.OwnerId == _userId);

            var service = new RoomService(_userId);
            var rooms = service.GetRooms().Where(r => r.MoveId == moveId).ToList();
            foreach (var room in rooms)
                service.DeleteRoom(room.RoomId);

            ctx.Moves.Remove(entity);
            return ctx.SaveChanges() == 1;
        }

    }
}
