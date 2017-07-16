using HeBoGuoShi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeBoGuoShi.Models.ProductViewModels
{
    public class OwnerProductViewModel
    {
        public OwnerProductViewModel() { }

        public OwnerProductViewModel(OwnerProduct dbModel)
        {
            this.Id = dbModel.Id;
            this.UserId = dbModel.UserId;
            this.Name = dbModel.Name;
            this.Price = dbModel.Price;
            this.Quantity = dbModel.Quantity;
            this.Margin = dbModel.Margin;
            this.Description = dbModel.Description;
            this.UserName = dbModel.User.UserName;

            if (dbModel.OwnerProductImages != null && dbModel.OwnerProductImages.Count > 0)
                this.ProfileImagePath = dbModel.OwnerProductImages.FirstOrDefault().Path;
            else
                this.ProfileImagePath = "/Imgs/diaochan.jpg";
        }

        public OwnerProductViewModel(SellerProduct dbModel)
        {
            this.Id = dbModel.Id;
            this.UserId = dbModel.UserId;
            this.Name = dbModel.OwnerProduct.Name;
            this.Price = dbModel.OwnerProduct.Price;
            this.Quantity = dbModel.OwnerProduct.Quantity;
            this.Margin = dbModel.OwnerProduct.Margin;
            this.Description = dbModel.OwnerProduct.Description;
            this.UserName = dbModel.User.UserName;

            if (dbModel.OwnerProduct.OwnerProductImages != null && dbModel.OwnerProduct.OwnerProductImages.Count > 0)
                this.ProfileImagePath = dbModel.OwnerProduct.OwnerProductImages.FirstOrDefault().Path;
            else
                this.ProfileImagePath = "/Imgs/diaochan.jpg";
        }


        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Margin { get; set; }
        public string Description { get; set; }
        public string ProfileImagePath { get; set; }
    }
}