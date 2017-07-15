using HeBoGuoShi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeBoGuoShi.Models.ProductViewModels
{
    public class SellerProductViewModel
    {
        public SellerProductViewModel() { }

        public SellerProductViewModel(SellerProduct dbModel)
        {
            this.Id = dbModel.Id;
            this.UserId = dbModel.UserId;
            this.OwnerProductId = dbModel.OwnerProductId;
            this.OwnerProduct = new OwnerProductViewModel(dbModel.OwnerProduct);
        }

        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid OwnerProductId { get; set; }
        public OwnerProductViewModel OwnerProduct { get; set; }
    }
}