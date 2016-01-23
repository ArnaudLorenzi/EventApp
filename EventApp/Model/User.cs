using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Model
{
    public class User
    {
        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string langKey;
        public string LangKey
        {
            get { return langKey; }
            set { langKey = value; }
        }

        private bool activated;
        public bool Activated
        {
            get { return activated; }
            set { activated = value; }
        }

        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        private DateTime? lastModifiedDate;
        public DateTime? LastModifiedDate
        {
            get { return lastModifiedDate; }
            set { lastModifiedDate = value; }
        }
        #endregion
    }
}
