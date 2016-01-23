using EventApp.Model;
using EventApp.Presentation;
using EventApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace EventApp.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MyAccount : Page
    {
        private UserViewModel vm;

        public MyAccount()
        {
            this.InitializeComponent();

            vm = new UserViewModel()
            {
                IsLogged = false
            };
            base.DataContext = vm;
        }

        /// <summary>
        ///     Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">
        ///     Event data that describes how this page was reached.  The Parameter
        ///     property is typically used to configure the page.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var usr = DataSource.DS.User;
            if (usr != null)
            {
                var rs = Windows.Storage.ApplicationData.Current.RoamingSettings;
                vm.Id = usr.Id;
                vm.Email = usr.Email;
                vm.Activated = usr.Activated;
                vm.CreatedDate = usr.CreatedDate;
                vm.FirstName = usr.FirstName;
                vm.LangKey = usr.LangKey;
                vm.LastModifiedDate = usr.LastModifiedDate;
                vm.LastName = usr.LastName;
                vm.Login = usr.Login;
                vm.IsLogged = (rs.Values["logged"] != null && (bool)rs.Values["logged"]);
            }
            else
                Frame.Navigate(typeof(Authentication));
        }

        private void LogoutButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Waiter.Visibility = Visibility.Visible;
            var rs = Windows.Storage.ApplicationData.Current.RoamingSettings;
            rs.Values["login"] = null;
            rs.Values["password"] = null;
            rs.Values["logged"] = false;
            DataSource.DS.Clear();
            RestHelper.Instance.SessionId = null;
            Waiter.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(Authentication));
        }
    }
}
