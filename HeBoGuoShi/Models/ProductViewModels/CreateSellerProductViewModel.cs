using HeBoGuoShi.DBModels;
using System.Collections.Generic;

namespace HeBoGuoShi.Models.ProductViewModels
{
    public class CreateSellerProductViewModel
    {
        public CreateSellerProductViewModel(List<OwnerProduct> ownerProducts)
        {
            this.OwnerProducts = new List<OwnerProductViewModel>();
            //this.SellerProducts = new List<SellerProductViewModel>();

            if (ownerProducts != null)
            {
                foreach (var ownerProduct in ownerProducts)
                {
                    var model = new OwnerProductViewModel(ownerProduct);
                    this.OwnerProducts.Add(model);
                }
            }

            //if (sellerProducts != null)
            //{
            //    foreach (var sellerProduct in sellerProducts)
            //    {
            //        var model = new SellerProductViewModel(sellerProduct);
            //        this.SellerProducts.Add(model);
            //    }
            //}
        }

        public List<OwnerProductViewModel> OwnerProducts { get; set; }
        //public List<SellerProductViewModel> SellerProducts { get; set; }
    }
}