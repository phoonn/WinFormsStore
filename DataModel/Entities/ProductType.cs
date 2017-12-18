using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    public class ProductType : BaseEntity
    {
        [Index(IsUnique = true),Required, MaxLength(70)]
        public string Type { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}
