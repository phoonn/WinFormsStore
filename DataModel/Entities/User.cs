using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Entities
{
    public class User : BaseEntity
    {
        [Index(IsUnique = true),MaxLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Alias { get; set; }
        public bool IsMaster { get; set; }
    }
}
