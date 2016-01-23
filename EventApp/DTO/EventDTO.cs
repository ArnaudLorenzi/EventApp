using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    [DataContract]
    public class EventDTO
    {
        [DataMember]
        public DateTime activationEndDate { get; set; }
        [DataMember]
        public DateTime activationStartDate { get; set; }
        //[DataMember]
        //public string admins { get; set; }
        [DataMember]
        public int allowedStorage { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public DateTime endDate { get; set; }
        [DataMember]
        public int? eventStateId { get; set; }
        [DataMember]
        public string eventStateLabel { get; set; }
        [DataMember]
        public int? eventTypeId { get; set; }
        [DataMember]
        public string eventTypeLabel { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string location { get; set; }
        //[DataMember]
        //public string members { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string ownerEmail { get; set; }
        [DataMember]
        public string ownerId { get; set; }
        [DataMember]
        public int pictureNb { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }
        [DataMember]
        public int usedStorage { get; set; }
    }
}
