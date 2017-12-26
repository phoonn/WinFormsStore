using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    public class Provider :BaseEntity
    {
        [Key, Browsable(false), Column(Order = 1, TypeName = "int")]
        public override int Id { get; set; }
        [Index(IsUnique = true), MaxLength(100), DisplayName("Доставчик")]
        public string ProviderName { get; set; }
        
        [Browsable(false)]
        public virtual ICollection<Product> Products { get; set; }
    }
}
