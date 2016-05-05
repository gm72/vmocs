using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMOCS.Models
{
    public class User
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual Company Company { get; set; }

    }
}
