using HeBoGuoShi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeBoGuoShi.DBModels
{
    [Table("SellerProducts")]
    public class SellerProduct
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid OwnerProductId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("OwnerProductId")]
        public virtual OwnerProduct OwnerProduct { get; set; }
    }
}
