using EventApp.Model;
using EventApp.Service;
using Intense.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Presentation
{
    public class PictureViewModel : NotifyPropertyChanged
    {

        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                Set(ref number, value);
                OnPropertyChanged("ThumbUrl");
                OnPropertyChanged("SmallUrl");
                OnPropertyChanged("SlideUrl");
                OnPropertyChanged("OriginalUrl");
            }
        }

        private int eventId;
        public int EventId
        {
            get { return eventId; }
            set
            {
                Set(ref eventId, value);
                OnPropertyChanged("ThumbUrl");
                OnPropertyChanged("SmallUrl");
                OnPropertyChanged("SlideUrl");
                OnPropertyChanged("OriginalUrl");
            }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { Set(ref fileName, value); }
        }

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
        #endregion

        public string buildURL(string size)
        {
            return RestHelper.Instance.buildURL("api/pictures/" + EventId + "/" + Number + "/" + size);
        }

    }
}
