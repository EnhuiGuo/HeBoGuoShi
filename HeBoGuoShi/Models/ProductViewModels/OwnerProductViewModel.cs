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
            this.Description = dbModel.Description;

            if (dbModel.OwnerProductImages != null && dbModel.OwnerProductImages.Count > 0)
                this.ProfileImagePath = dbModel.OwnerProductImages.FirstOrDefault().Path;
        }


        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ProfileImagePath { get; set; }
    }
}