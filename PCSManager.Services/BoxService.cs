using PCSManager.Data;
using PCSManager.Models.Box;
using PCSManager.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Services
{
    public class BoxService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        private readonly Guid _userId;
        public BoxService(Guid userId)
        { _userId = userId; }

        public bool CreateBox(BoxCreate model)
        {
            var entity =
                new Box()
                {
                    BoxSize = model.BoxSize
                };
            {
                ctx.Boxes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<BoxListItem> GetBoxes()
        {
            var query =
                ctx.Boxes.Select
                (e =>
                new BoxListItem
                {
                    BoxId = e.BoxId,
                    RoomId = e.RoomId

                });
            return query.ToArray();
        }


        public BoxDetail GetBoxId(int id)
        {
            var entity =
                ctx.Boxes.Single(e => e.BoxId == id);
            return
                new BoxDetail
                {
                    BoxSize = entity.BoxSize,
                    RoomId = entity.RoomId
                };
        }


        public bool UpdateBox(BoxEdit model)
        {
            var entity =
                ctx.Boxes
                .Single(e => e.BoxId == model.BoxId);
            entity.BoxSize = model.BoxSize;
            return ctx.SaveChanges() == 1;
        }


        public bool DeleteBox(int boxId)
        {
            var entity =
                ctx.Boxes.Single(e => e.BoxId == boxId);
            ctx.Boxes.Remove(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
