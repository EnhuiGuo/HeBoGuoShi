using System.ComponentModel.DataAnnotations;


namespace HeBoGuoShi.Models.ProductViewModels
{
    public class CreateOwnerProductViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "名字不能为空。")]
        [Display(Name = "产品名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "价格不能为空。")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Range(0, 1000000, ErrorMessage = "不能大于1000000")]
        [Display(Name = "产品价格")]
        public float Price { get; set; }

        [Display(Name = "数量")]
        public int Quantity { get; set; }

        [Display(Name = "产品描述")]
        public string Description { get; set; }
    }
}