using Intense.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Presentation
{
    public class UserViewModel : NotifyPropertyChanged
    {
        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { Set(ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { Set(ref lastName, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { Set(ref email, value); }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set { Set(ref login, value); }
        }

        private string langKey;
        public string LangKey
        {
            get { return langKey; }
            set { Set(ref langKey, value); }
        }

        private bool activated;
        public bool Activated
        {
            get { return activated; }
            set { Set(ref isLogged, value); }
        }

        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { Set(ref createdDate, value); }
        }

        private DateTime? lastModifiedDate;
        public DateTime? LastModifiedDate
        {
            get { return lastModifiedDate; }
            set { Set(ref lastModifiedDate, value); }
        }

        private bool isLogged;
        public bool IsLogged
        {
            get { return isLogged; }
            set { Set(ref isLogged, value); }
        }
        #endregion
    }
}
