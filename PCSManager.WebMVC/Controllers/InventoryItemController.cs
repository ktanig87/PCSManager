﻿using System;
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
            return View();
        }
    }
}