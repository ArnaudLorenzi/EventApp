using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class PictureDTO
    {
        public int eventId { get; set; }
        public string eventName { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public int id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string ownerEmail { get; set; }
        public int ownerId { get; set; }
        public DateTime pictureDate { get; set; }
        public int pictureStateId { get; set; }
        public string pictureStateLabel { get; set; }
        public int size { get; set; }
        public string thumbFileName { get; set; }
        public string thumbFilePath { get; set; }
    }

}
