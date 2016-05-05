using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMOCS.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
