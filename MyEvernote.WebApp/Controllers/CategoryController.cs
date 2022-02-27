using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using MyEvernoteBusinessLayer;
using MyEvernoteEntities;

namespace MyEvernote.WebApp.Controllers
{
    public class CategoryController : Controller
    {
    //    // GET: TempData ile category listeleme
    //    public ActionResult Select(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        CategoryManager cm = new CategoryManager();
    //        Category cat= cm.GetCategoryById(id.Value);


    //        if (cat == null)
    //        {
    //            return HttpNotFound();
    //            //return RedirectToAction("Index", "Home");
    //        }
    //        TempData["mm"] = cat.Notes;
    //        return RedirectToAction("Index", "Home");
    //    }
    }
}