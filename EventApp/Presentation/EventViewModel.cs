using EventApp.Model;
using EventApp.Service;
using Intense.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Presentation
{
    public class EventViewModel : NotifyPropertyChanged
    {
        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { Set(ref location, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { Set(ref description, value); }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { Set(ref startDate, value); }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { Set(ref endDate, value); }
        }

        private DateTime activationStartDate;
        public DateTime ActivationStartDate
        {
            get { return activationStartDate; }
            set { Set(ref activationStartDate, value); }
        }

        private DateTime activationEndDate;
        public DateTime ActivationEndDate
        {
            get { return activationEndDate; }
            set { Set(ref activationEndDate, value); }
        }

        private EventType eventType;
        public EventType EventType
        {
            get { return eventType; }
            set { Set(ref eventType, value); }
        }

        private int pictureNb;
        public int PictureNb
        {
            get { return pictureNb; }
            set { Set(ref pictureNb, value); }
        }

        private int allowedStorage;
        public int AllowedStorage
        {
            get { return allowedStorage; }
            set { Set(ref allowedStorage, value); }
        }

        private int usedStorage;
        public int UsedStorage
        {
            get { return usedStorage; }
            set { Set(ref usedStorage, value); }
        }

        private string thumbUrl;
        public string ThumbUrl
        {
            get { return thumbUrl; }
            set { Set(ref thumbUrl, value); }
        }
        
        private ObservableCollection<Picture> pictures;
        public ObservableCollection<Picture> Pictures
        {
            get { return pictures; }
        }
        #endregion

        public EventViewModel()
        {
            pictures = new ObservableCollection<Picture>();
        }
    }
}
