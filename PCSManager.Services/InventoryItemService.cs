using PCSManager.Data;
using PCSManager.Models.InventoryItem;
using PCSManager.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Services
{
    public class InventoryItemService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public InventoryItemService(Guid userId)
        { _userId = userId; }

        public bool CreateItem(InventoryItemCreate model)
        {
            var entity =
                new InventoryItem()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Condition = model.Condition,
                    ItemValue = model.ItemValue,
                    UPC = model.UPC,
                    BoxId = model.BoxId,
                    RoomId = model.RoomId
                };


            {
                ctx.InventoryItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InventoryItemListItem> GetInventoryItems()
        {
            var query =
                ctx.InventoryItems.Select
                (e =>
                new InventoryItemListItem
                {
                    InventoryId = e.InventoryId,
                    Name = e.Name,

                }
                );
            return query.ToArray();
        }


        public InventoryItemDetail GetItemById(int id)
        {
            var entity =
                ctx.InventoryItems.Single(e => e.InventoryId == id);
            return
                new InventoryItemDetail
                {
                    InventoryId = entity.InventoryId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Condition = entity.Condition,
                    ItemValue = entity.ItemValue,
                    HighValue = entity.HighValue,
                    UPC = entity.UPC,

                };
        }


        public bool UpdateInventoryItem(InventoryItemEdit model)
        {
            var entity =
                ctx.InventoryItems.Single(e => e.InventoryId == model.InventoryId);
            entity.InventoryId = model.InventoryId;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Condition = model.Condition;
            entity.ItemValue = model.ItemValue;
            entity.UPC = model.UPC;
            entity.BoxId = model.BoxId;
            entity.RoomId = model.RoomId;
            return ctx.SaveChanges() == 1;
        }

        public bool DeleteInventoryItem(int inventoryId)
        {
            var entity =
                ctx.InventoryItems.Single(e => e.InventoryId == inventoryId);
            ctx.InventoryItems.Remove(entity);
            return ctx.SaveChanges() == 1;
        }

    }
}
