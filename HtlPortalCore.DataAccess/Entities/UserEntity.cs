using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HtlPortalCore.DataAccess.Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity<string>
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
        
        [MaxLength(255)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        [MaxLength(255), Required]
        public string PhoneNumber { get; set; }


        [MaxLength(255), Required]
        public string UserName { get; set; }
    }
}
