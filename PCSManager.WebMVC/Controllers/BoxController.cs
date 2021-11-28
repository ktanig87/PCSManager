using Microsoft.AspNet.Identity;
using PCSManager.Models.Box;
using PCSManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCSManager.WebMVC.Controllers
{
    [Authorize]
    public class BoxController : Controller
    {
        // GET: Box
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoxService(userId);
            var model = service.GetBoxes();

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
        public ActionResult Create(BoxCreate model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDownLists();
                return View(model);
            }
            var service = CreateBoxService();

            if (service.CreateBox(model))
            {
                TempData["SaveResult"] = "Your Box was Created";
                return RedirectToAction("index");
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBoxService();
            var model = svc.GetBoxId(id);
            PopulateDropDownLists();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBoxService();
            var detail = service.GetBoxId(id);
            var model =
                new BoxEdit
                {
                    BoxId = detail.BoxId,
                    BoxSize = detail.BoxSize,
                    MoveId = detail.MoveId,
                    RoomId = detail.RoomId
                };
            PopulateDropDownLists();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BoxEdit model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDownLists();
                return View(model);
            }
            if (model.BoxId != id)
            {
                ModelState.AddModelError("", "Invalid ID");
                PopulateDropDownLists();
                return View(model);
            }

            var service = CreateBoxService();
            if (service.UpdateBox(model))
            {
                TempData["SaveResult"] = "Your Box has been updated";
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "Your Box could not be updated");
            PopulateDropDownLists();
            return View(model);
        }
        
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBoxService();
            var model = svc.GetBoxId(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBox(int id)
        {
            var service = CreateBoxService();
            service.DeleteBox(id);
            TempData["SaveResult"] = "Your Box was deleted successfully";
            return RedirectToAction("index");
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

        private void PopulateDropDownLists()
        {
            ViewBag.Moves = PopulateMovesList();
            ViewBag.Rooms = PopulateRoomsList();
        }
        private BoxService CreateBoxService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoxService(userId);
            return service;
        }
    }
}