using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtlPortalCore.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }        
        public string PhoneNumber { get; set; }  
        
        public string UserName { get; set; }        

        public bool IsActive { get; set; }
    }
}
