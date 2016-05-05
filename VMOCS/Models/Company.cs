using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMOCS.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        
        public string CompanyName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }

        
        public virtual ICollection<User> Users { get; set; }
    }
}
