using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HeBoGuoShi.DBModels;
using Microsoft.AspNet.Identity;
using HeBoGuoShi.Models.ProductViewModels;
using System.Collections.Generic;

namespace HeBoGuoShi.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerProductsController : Controller
    {
        private HeboContext db = new HeboContext();

        // GET: SellerProducts
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var sellerProducts = db.SellerProducts.Where(x=>x.UserId == userId).ToList();

            var model = new List<SellerProductViewModel>();

            if (sellerProducts != null && sellerProducts.Count() > 0)
            {
                foreach (var sellerProduct in sellerProducts)
                {
                    var item = new SellerProductViewModel(sellerProduct);
                    model.Add(item);
                }
            }

            return View(model);
        }

        // GET: SellerProducts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerProduct sellerProduct = db.SellerProducts.Find(id);
            if (sellerProduct == null)
            {
                return HttpNotFound();
            }
            return View(sellerProduct);
        }

        // GET: SellerProducts/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var sellerProducts = db.SellerProducts.Where(x => x.UserId == userId).ToList();
            var ownerProducts = db.OwnerProducts.ToList().Where(x => !sellerProducts.Select(y => y.OwnerProductId).ToList().Contains(x.Id)).ToList();

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

        // POST: SellerProducts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,UserId,OwnerProductId")] SellerProduct sellerProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        sellerProduct.Id = Guid.NewGuid();
        //        db.SellerProducts.Add(sellerProduct);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.OwnerProductId = new SelectList(db.OwnerProducts, "Id", "UserId", sellerProduct.OwnerProductId);
        //    ViewBag.UserId = User.Identity.GetUserId();
        //    return View(sellerProduct);
        //}

        [HttpPost]
        public JsonResult Create(Guid productId)
        {

            try
            {
                if (productId != null)
                {
                    var userId = User.Identity.GetUserId();
                    var exist = db.SellerProducts.Any(x => x.UserId == userId && x.OwnerProductId == productId);

                    if (!exist)
                    {
                        var newSellerProduct = new SellerProduct();
                        {
                            newSellerProduct.OwnerProductId = productId;
                            newSellerProduct.UserId = userId;
                        }

                        db.SellerProducts.Add(newSellerProduct);
                        db.SaveChanges();
                    }
                }

                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        // GET: SellerProducts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerProduct sellerProduct = db.SellerProducts.Find(id);
            if (sellerProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerProductId = new SelectList(db.OwnerProducts, "Id", "UserId", sellerProduct.OwnerProductId);
            ViewBag.UserId = User.Identity.GetUserId();
            return View(sellerProduct);
        }

        // POST: SellerProducts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,OwnerProductId")] SellerProduct sellerProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellerProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerProductId = new SelectList(db.OwnerProducts, "Id", "UserId", sellerProduct.OwnerProductId);
            ViewBag.UserId = User.Identity.GetUserId();
            return View(sellerProduct);
        }

        // GET: SellerProducts/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SellerProduct sellerProduct = db.SellerProducts.Find(id);
        //    if (sellerProduct == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sellerProduct);
        //}

        [HttpPost]
        public JsonResult Delete(Guid? id)
        {
            if (id == null)
            {
                return Json(false);
            }
            else
            {
                try
                {
                    var sellerProduct = db.SellerProducts.Find(id);

                    db.SellerProducts.Remove(sellerProduct);
                    db.SaveChanges();

                    return Json(true);
                }
                catch
                {
                    return Json(false);
                }
            }
        }

        // POST: SellerProducts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    SellerProduct sellerProduct = db.SellerProducts.Find(id);
        //    db.SellerProducts.Remove(sellerProduct);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
