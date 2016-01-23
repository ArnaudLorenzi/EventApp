using EventApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Model
{
    public class Event
    {
        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private DateTime activationStartDate;
        public DateTime ActivationStartDate
        {
            get { return activationStartDate; }
            set { activationStartDate = value; }
        }

        private DateTime activationEndDate;
        public DateTime ActivationEndDate
        {
            get { return activationEndDate; }
            set { activationEndDate = value; }
        }

        private EventState eventState;
        public EventState EventState
        {
            get { return eventState; }
            set { eventState = value; }
        }

        private EventType eventType;
        public EventType EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        private List<User> members;
        public List<User> Members
        {
            get { return members; }
        }

        private User owner;
        public User Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        
        private int pictureNb;
        public int PictureNb
        {
            get { return pictureNb; }
            set { pictureNb = value; }
        }

        private List<Picture> pictures;
        public List<Picture> Pictures
        {
            get { return pictures; }
        }

        private int allowedStorage;
        public int AllowedStorage
        {
            get { return allowedStorage; }
            set { allowedStorage = value; }
        }

        private int usedStorage;
        public int UsedStorage
        {
            get { return usedStorage; }
            set { usedStorage = value; }
        }

        public string ThumbUrl
        {
            get { return RestHelper.Instance.buildURL("api/events/" + Id + "/thumb"); }
        }
        #endregion

        public Event()
        {
            members = new List<User>();
            pictures = new List<Picture>();
        }
    }
}
