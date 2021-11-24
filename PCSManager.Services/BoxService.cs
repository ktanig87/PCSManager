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
                    BoxSize = model.BoxSize,
                    RoomId = model.RoomId
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
                    RoomId = (int)e.RoomId

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
                    BoxId = entity.BoxId,
                    BoxSize = entity.BoxSize,
                    RoomId = (int)entity.RoomId,
                    MoveId = entity.Room.MoveId
                };
        }


        public bool UpdateBox(BoxEdit model)
        {
            var entity =
                ctx.Boxes
                .Single(e => e.BoxId == model.BoxId);
            entity.BoxId = model.BoxId;
            entity.BoxSize = model.BoxSize;
            entity.RoomId = model.RoomId;
            return ctx.SaveChanges() == 1;
        }


        public bool DeleteBox(int boxId)
        {
            var entity =
                ctx.Boxes.Single(e => e.BoxId == boxId);
            //var inventoryItems = ctx.InventoryItems.Where(i => i.BoxId == boxId).ToList();
            //foreach (var items in inventoryItems)
            //    ctx.InventoryItems.Remove(items);
            var service = new InventoryItemService(_userId);
            var items = service.GetInventoryItems().Where(i => i.BoxId == boxId).ToList();
            foreach (var item in items)
                service.DeleteInventoryItem(item.InventoryId);
            ctx.Boxes.Remove(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
