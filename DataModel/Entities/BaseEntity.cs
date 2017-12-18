using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Interfaces;

namespace DataModel.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key,DisplayName("Номер на поръчка"),Column(Order=1,TypeName ="int")]
        public virtual int Id {get;set;}
    }
}
