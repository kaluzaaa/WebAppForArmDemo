using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppForArmDemo.Utils;
using WebAppForArmDemo.Models;

namespace WebAppForArmDemo.Controllers
{
    public class PhotoItemsController : Controller
    {
        private PhotoInBlob context = new PhotoInBlob();
        // GET: PhotoItem
        public ActionResult Index()
        {
            return View(context.Get());
        }

        // GET: PhotoItem/Details/5
        public ActionResult Details(string Id)
        {
            return View(context.Get(Id));
        }

        // GET: PhotoItem/Create
        public ActionResult Upload()
        {
            return View();
        }

        // POST: PhotoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            context.Upload(photo);
            return RedirectToAction("Index");
        }

        // GET: PhotoItem/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoItem photoItem = context.Get(id);
            if (photoItem == null)
            {
                return HttpNotFound();
            }
            return View(photoItem);
        }

        // POST: PhotoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedDelete(string id)
        {
            context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
