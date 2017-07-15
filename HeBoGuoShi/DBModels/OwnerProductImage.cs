using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeBoGuoShi.DBModels
{
    [Table("OwnerProductImages")]
    public class OwnerProductImage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        [ForeignKey("ProductId")]
        public virtual OwnerProduct OwnProduct { get; set; }
    }
}
