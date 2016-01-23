using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class InvitationCreateDTO
    {
        public string email { get; set; }
        public int eventId { get; set; }
        public string message { get; set; }
    }
}
