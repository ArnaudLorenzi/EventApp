using EventApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Model
{
    public class Picture
    {
        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Event eventt;
        public Event Eventt
        {
            get { return eventt; }
            set { eventt = value; }
        }

        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        private User owner;
        public User Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private DateTime pictureDate;
        public DateTime PictureDate
        {
            get { return pictureDate; }
            set { pictureDate = value; }
        }

        private int size;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        #endregion

        public string ThumbUrl
        {
            get { return buildURL("thumb"); }
        }

        public string SmallUrl
        {
            get { return buildURL("small"); }
        }

        public string SlideUrl
        {
            get { return buildURL("slide"); }
        }

        public string OriginalUrl
        {
            get { return buildURL("original"); }
        }

        public string buildURL(string size)
        {
            return RestHelper.Instance.buildURL("api/pictures/" + Eventt.Id + "/" + Number + "/" + size);
        }

    }
}
