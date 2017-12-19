using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DataModel.Entities
{
    public class SerialNumber :BaseEntity
    {
        [DisplayName("Сериен Номер"),Column(Order=2),Index(IsUnique =true),MaxLength(40)]
        public string SerialNum { get; set; }
        [DisplayName("Parent"),Column(Order=3),ForeignKey("Product")]
        public int ProductId { get; set; }
        [NotMapped]
        public bool Modified { get; set; }

        public virtual Product Product { get; set; }
    }
}
