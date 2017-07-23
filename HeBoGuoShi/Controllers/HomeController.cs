using HeBoGuoShi.DBModels;
using HeBoGuoShi.Models.ProductViewModels;
using Microsoft.AspNet.Identity;
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
            //var ownerProducts = db.OwnerProducts.ToList();
            var sellerProducts = db.SellerProducts.ToList();

            var model = new List<OwnerProductViewModel>();


            //if (ownerProducts != null)
            //{
            //    foreach (var ownerProduct in ownerProducts)
            //    {
            //        var item = new OwnerProductViewModel(ownerProduct);
            //        model.Add(item);
            //    }
            //}

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

        [HttpPost]
        public JsonResult AddToCart(Guid productId)
        {
            var userId = User.Identity.GetUserId();

            if (userId == null && Session["CartId"] == null)
            {
                Cart newCart = new Cart();
                var cart = db.Carts.Add(newCart);
                db.SaveChanges();
                Session["CartId"] = cart.Id;
            }
            else
            {
                var cart = db.Carts.FirstOrDefault(x => x.UserId == userId);

                if (cart == null)
                {
                    var newCart = new Cart();
                    {
                        newCart.UserId = userId;
                        newCart.CartItems = new List<CartItem>();
                    }

                    cart = db.Carts.Add(newCart);
                }

                var cartItem = new CartItem();
                {
                    cartItem.ProductId = productId;
                }

                cart.CartItems.Add(cartItem);

                db.SaveChanges();

            }

            return Json(true);
        }
    }
}