using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class InvitationDTO
    {
        public string email { get; set; }
        public int eventId { get; set; }
        public string eventName { get; set; }
        public int id { get; set; }
        public DateTime invitationDate { get; set; }
        public int invitationStateId { get; set; }
        public string invitationStateLabel { get; set; }
        public string message { get; set; }
        public DateTime responseDate { get; set; }
    }
}
