using HeBoGuoShi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeBoGuoShi.Models.ProductViewModels
{
    public class AddProductImagesViewModel
    {
        public Guid ProductId { get; set; }

        public List<OwnerProductImage> Images { get; set; }
    }
}