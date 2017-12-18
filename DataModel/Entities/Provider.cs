using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    public class Provider :BaseEntity
    {
        [Index(IsUnique = true), MaxLength(100)]
        public string ProviderName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
