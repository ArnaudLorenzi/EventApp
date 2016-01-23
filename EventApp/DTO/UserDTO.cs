using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class UserDTO
    {
        public bool activated { get; set; }
        public DateTime createdDate { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public int id { get; set; }
        public string langKey { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime? lastModifiedDate { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }

}
