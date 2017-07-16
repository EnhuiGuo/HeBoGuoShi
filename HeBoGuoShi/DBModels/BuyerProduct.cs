using HeBoGuoShi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeBoGuoShi.DBModels
{
    [Table("BuyerProducts")]
    public class BuyerProduct
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid SellerProductId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("SellerProductId")]
        public virtual SellerProduct SellerProduct { get; set; }
    }
}