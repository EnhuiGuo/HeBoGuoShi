using HeBoGuoShi.DBModels;
using HeBoGuoShi.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeBoGuoShi.Controllers
{
    public class HomeController : Controller
    {
        private HeboContext db = new HeboContext();
        public ActionResult Index()
        {
            var ownerProducts = db.OwnerProducts.ToList();
            var sellerProducts = db.SellerProducts.ToList();

            var model = new List<OwnerProductViewModel>();


            if (ownerProducts != null)
            {
                foreach (var ownerProduct in ownerProducts)
                {
                    var item = new OwnerProductViewModel(ownerProduct);
                    model.Add(item);
                }
            }

            if (sellerProducts != null)
            {
                foreach (var sellerProduct in sellerProducts)
                {
                    var item = new OwnerProductViewModel(sellerProduct);
                    model.Add(item);
                }
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}