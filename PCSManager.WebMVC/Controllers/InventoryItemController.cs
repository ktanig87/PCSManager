using Microsoft.AspNet.Identity;
using PCSManager.Models.InventoryItem;
using PCSManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCSManager.WebMVC.Controllers
{
    public class InventoryItemController : Controller
    {
        // GET: InventoryItem
        public ActionResult Index()
        {
            var service = CreateInventoryItemService();
            var model = service.GetInventoryItems();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDownLists();
                return View(model);
            }

            var service = CreateInventoryItemService();

            if (service.CreateItem(model))
            {
                TempData["SaveResult"] = "Your Inventory Item was created.";
                return RedirectToAction("index");
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateInventoryItemService();
            var model = svc.GetItemById(id);
            PopulateDropDownLists();
            return View(model);
        }

        public ActionResult Edit(int id)
        {            
            var service = CreateInventoryItemService();
            var detail = service.GetItemById(id);
            var model =
                new InventoryItemEdit
                {
                    InventoryId = detail.InventoryId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Condition = detail.Condition,
                    ItemValue = detail.ItemValue,
                    UPC = detail.UPC,
                    BoxId = detail.BoxId,
                    RoomId = detail.RoomId
                };
            PopulateDropDownLists();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryItemEdit model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDownLists();
                return View(model);
            }
            if (model.InventoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                PopulateDropDownLists();
                return View(model);
            }

            var service = CreateInventoryItemService();

            if (service.UpdateInventoryItem(model))
            {
                TempData["SaveResult"] = "You inventory item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your inventory could not be updated");
            PopulateDropDownLists();
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateInventoryItemService();
            var model = svc.GetItemById(id);
            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInventoryItemService();
            service.DeleteInventoryItem(id);
            TempData["SaveResult"] = "Your Inventory Item was deleted";
            return RedirectToAction("index");
        }

        private void PopulateDropDownLists()
        {
            ViewBag.Moves = PopulateMovesList();
            ViewBag.Rooms = PopulateRoomsList();
            ViewBag.Boxes = PopulateBoxesList();
        }

        private List<SelectListItem> PopulateMovesList()
        {
            var service = new MoveInfoService(Guid.Parse(User.Identity.GetUserId()));
            List<SelectListItem> moves = new List<SelectListItem>();
            foreach (var move in service.GetMoves())
                moves.Add(new SelectListItem { Text = move.Id + " " + move.MoverName, Value = move.Id.ToString() });
            return moves;
        }
        private List<SelectListItem> PopulateRoomsList()
        {
            var service = new RoomService(Guid.Parse(User.Identity.GetUserId()));
            List<SelectListItem> rooms = new List<SelectListItem>();
            foreach (var room in service.GetRooms())
                rooms.Add(new SelectListItem { Text = room.RoomId + " " + room.RoomName, Value = room.RoomId.ToString() });
            return rooms;
        }

        private List<SelectListItem> PopulateBoxesList()
        {
            var service = new BoxService(Guid.Parse(User.Identity.GetUserId()));
            List<SelectListItem> boxes = new List<SelectListItem>();
            foreach (var box in service.GetBoxes())
                boxes.Add(new SelectListItem { Text = box.BoxId + " ", Value = box.BoxId.ToString() });
            return boxes;
        }
        private InventoryItemService CreateInventoryItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryItemService(userId);
            return service;
        }
    }
}