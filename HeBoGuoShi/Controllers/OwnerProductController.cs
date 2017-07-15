using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HeBoGuoShi.DBModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web;
using System.IO;
using HeBoGuoShi.Models.ProductViewModels;

namespace HeBoGuoShi.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerProductController : Controller
    {
        private HeboContext db = new HeboContext();

        // GET: OwnerProducts
        public ActionResult Index()
        {
            var ownerProducts = db.OwnerProducts.Include(o => o.User).ToList();

            var model = new List<OwnerProductViewModel>();

            if (ownerProducts != null)
            {
                foreach (var ownerProduct in ownerProducts)
                {
                    var item = new OwnerProductViewModel(ownerProduct);
                    model.Add(item);
                }
            }

            return View(model);
        }

        // GET: OwnerProducts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerProduct ownerProduct = db.OwnerProducts.Find(id);
            if (ownerProduct == null)
            {
                return HttpNotFound();
            }
            return View(ownerProduct);
        }

        // GET: OwnerProducts/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }

        // POST: OwnerProducts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Name,Price,Quantity,Description")] OwnerProduct ownerProduct)
        {
            if (ModelState.IsValid)
            {
                ownerProduct.Id = Guid.NewGuid();
                db.OwnerProducts.Add(ownerProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = User.Identity.GetUserId();
            return View(ownerProduct);
        }

        // GET: OwnerProducts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerProduct ownerProduct = db.OwnerProducts.Find(id);
            if (ownerProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = User.Identity.GetUserId();
            return View(ownerProduct);
        }

        // POST: OwnerProducts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Name,Price,Quantity,Description")] OwnerProduct ownerProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownerProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = User.Identity.GetUserId();
            return View(ownerProduct);
        }

        // GET: OwnerProducts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerProduct ownerProduct = db.OwnerProducts.Find(id);
            if (ownerProduct == null)
            {
                return HttpNotFound();
            }
            return View(ownerProduct);
        }

        // POST: OwnerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OwnerProduct ownerProduct = db.OwnerProducts.Find(id);
            db.OwnerProducts.Remove(ownerProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaveImages(IEnumerable<HttpPostedFileBase> files, Guid id)
        {
            //the name of the upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Guid.NewGuid().ToString()+ Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Imgs"), fileName);

                    file.SaveAs(physicalPath);

                    var itemImage = new OwnerProductImage();
                    {
                        itemImage.ProductId = id;
                        itemImage.Path = "/Imgs/" + fileName;
                        itemImage.Name = Path.GetFileName(file.FileName);
                    }

                    db.OwnerProductImages.Add(itemImage);
                }

                db.SaveChanges();
            }

            return Content("");
        }

        public ActionResult RemoveImages(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/Imgs"), fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult RemoveImage(Guid id)
        {
            try
            {
                var image = db.OwnerProductImages.Find(id);
                db.OwnerProductImages.Remove(image);
                db.SaveChanges();

                var path = image.Path;

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult _ProductImagesDetail(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerProduct ownerProduct = db.OwnerProducts.Find(id);
            if (ownerProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView(ownerProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
