using HeBoGuoShi.DBModels;
using HeBoGuoShi.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HeBoGuoShi.Controllers
{
    public class ProductController : Controller
    {
        private HeboContext db = new HeboContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var sellerProduct = db.SellerProducts.Find(id);

            if (sellerProduct != null)
            {
                var model = new OwnerProductViewModel(sellerProduct);

                return View(model);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}