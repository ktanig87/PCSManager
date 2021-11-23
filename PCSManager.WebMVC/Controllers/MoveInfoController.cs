using Microsoft.AspNet.Identity;
using PCSManager.Models.MoveInfo;
using PCSManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCSManager.WebMVC.Controllers
{
    [Authorize]
    public class MoveInfoController : Controller
    {
        // GET: MoveInfo
        public ActionResult Index()
        {
            var service = CreateMoveInfoService();
            var model = service.GetMoves();
            return View(model);
        }

        //Get
        public ActionResult Create()
        { return View(); }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoveInfoCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateMoveInfoService();
            if (service.CreateMove(model))
            {
                TempData["SaveResult"] = "Your Move was added successfully!";
                return RedirectToAction("index"); ;
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateMoveInfoService();
            var model = service.GetMovebyId(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMoveInfoService();
            var detail = service.GetMovebyId(id);
            var model =
                new MoveInfoEdit
                {
                    MoverName = detail.MoverName,
                    DriverPhone = detail.DriverPhone,
                    PickupDate = detail.PickupDate,
                    DeliveryDate = detail.DeliveryDate,
                    TSPPhone = detail.TSPPhone
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MoveInfoEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Invalid.  Please try again.");
                return View(model);
            }
            var service = CreateMoveInfoService();
            if (service.UpdateMove(model))
            {
                TempData["SaveResult"] = "Your Move has been updated!";
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "Your Move could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMoveInfoService();
            var model = svc.GetMovebyId(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMove(int id)
        {
            var service = CreateMoveInfoService();
            service.DeleteMove(id);
            TempData["SaveResult"] = "Your Move has been deleted.";
            return RedirectToAction("index");
        }

        private MoveInfoService CreateMoveInfoService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MoveInfoService(userId);
            return service;
        }
    }
}