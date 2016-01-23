using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.DTO
{
    public class PictureCommentCreateDTO
    {
        public string comment { get; set; }
        public int pictureId { get; set; }
    }
}
