using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeBoGuoShi.DBModels
{
    [Table("CartItems")]
    public class CartItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual SellerProduct Product { get; set; }
    }
}