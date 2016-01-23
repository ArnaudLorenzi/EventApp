using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Model
{
    public class DataSource
    {
        # region Fields
        private static DataSource ds;
        public static DataSource DS
        {
            get
            {
                if (ds == null)
                {
                    ds = new DataSource();
                }
                return ds;
            }
        }

        private List<Event> events;
        public List<Event> Events
        {
            get { return events; }
        }

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        private DataSource()
        {
            events = new List<Event>();
        }

        public void Clear() {
            Events.Clear();
            User = null;
        }

        public Event GetEvent(int id)
        {
            return Events.First(e => e.Id == id);
        }

    }
}
