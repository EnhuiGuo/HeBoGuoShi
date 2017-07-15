using HeBoGuoShi.DBModels;
using System;
using System.Collections.Generic;

namespace HeBoGuoShi.Models.ProductViewModels
{
    public class DetailOwnerProductViewModel
    {
        public DetailOwnerProductViewModel()
        {
            this.OwnerProductImages = new List<OwnerProductImage>();
        }

        public DetailOwnerProductViewModel(OwnerProduct product)
        {
            this.OwnerProductImages = new List<OwnerProductImage>();

            this.Id = product.Id;
            this.UserId = product.UserId;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Quantity = product.Quantity;
            this.Description = product.Description;
            this.User = product.User;

            if (product.OwnerProductImages != null && product.OwnerProductImages.Count > 0)
            {
                foreach (var productImage in product.OwnerProductImages)
                {
                    this.OwnerProductImages.Add(productImage);
                }
            }
        }

        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }

        public List<OwnerProductImage> OwnerProductImages { get; set; }
    }
}