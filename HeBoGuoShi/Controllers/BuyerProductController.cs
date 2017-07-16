using HeBoGuoShi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeBoGuoShi.Controllers
{
    public class BuyerProductController : Controller
    {
        private HeboContext db = new HeboContext();
        // GET: BuyerProduct
        public ActionResult Index()
        {
            return View();
        }

        // GET: BuyerProduct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuyerProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyerProduct/Create
        [HttpPost]
        public ActionResult Create(Guid ownerProductId)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyerProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BuyerProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyerProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BuyerProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
