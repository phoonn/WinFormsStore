using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    public class Product : BaseEntity
    {
        [Key, Browsable(false), Column(TypeName = "int")]
        public override int Id { get; set; }

        [DisplayName("Номер"),Column(Order=2),Index(IsUnique =true),MaxLength(100)]
        public string Number { get; set; }
        
        [DisplayName("Име"), Column(Order = 3)]
        public string ProductName { get; set; }

        [Browsable(false), Column(Order = 4),ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }

        [DisplayName("Брой"), Column(Order = 5)]
        public int Quantity { get; set; }
        
        [DisplayName("Платена цена"), Column(Order = 6)]
        public double PricePaid { get; set; }

        [DisplayName("Цена без ДДС"), Column(Order = 7)]
        public double PriceWithoutVat { get; set; }

        [DisplayName("Цена"), Column(Order = 8)]
        public double Price { get; set; }

        [Column(Order=9),ForeignKey("Provider"), Browsable(false)]
        public int ProviderId { get; set; }

        [NotMapped,DisplayName("Доставчик")]
        public string ProviderName { get; set; }
        [NotMapped, DisplayName("Тип")]
        public string ProductTypeName { get; set; }

        [Browsable(false)]
        public virtual Provider Provider { get; set; }
        [Browsable(false)]
        public virtual ProductType ProductType { get; set; }
        [Browsable(false)]
        public virtual ICollection<SerialNumber> SerialNumbers { get; set; }
    }
}
