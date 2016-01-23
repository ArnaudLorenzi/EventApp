using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class PictureTopDTO
    {
        public int id { get; set; }
        public string pictureFileName { get; set; }
        public int pictureId { get; set; }
        public bool top { get; set; }
        public string userEmail { get; set; }
        public int userId { get; set; }
    }
}
