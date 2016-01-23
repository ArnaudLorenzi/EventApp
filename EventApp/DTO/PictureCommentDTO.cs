using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class PictureCommentDTO
    {
        public string comment { get; set; }
        public int id { get; set; }
        public string pictureFileName { get; set; }
        public int pictureId { get; set; }
        public string userEmail { get; set; }
        public int userId { get; set; }
    }
}
