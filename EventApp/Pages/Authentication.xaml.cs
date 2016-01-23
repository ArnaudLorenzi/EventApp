using EventApp.Model;
using EventApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Authentication : Page
    {
        //MainPage rootPage = MainPage.Current;

        public Authentication()
        {
            this.InitializeComponent();
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
            AutoLogin();
        }

        private async void AutoLogin()
        {
            var rs = Windows.Storage.ApplicationData.Current.RoamingSettings;
            if (rs.Values["logged"] != null && (bool)rs.Values["logged"])
            {
                AutoLoginWaiter.Visibility = Visibility.Visible;
                if (await DoLogin(rs.Values["login"].ToString(), rs.Values["password"].ToString()))
                {
                    await RestApiManager.GetOwnedEvents();
                    Frame.Navigate(typeof(MyEventList));
                    return;
                }
                AutoLoginWaiter.Visibility = Visibility.Collapsed;
            }
        }

        private async Task<Boolean> DoLogin(String login, String password)
        {
            var rs = Windows.Storage.ApplicationData.Current.RoamingSettings;
            var ok = await RestApiManager.Authenticate(login, password);
            var retUsr = await RestApiManager.GetUser(login);
            ok = retUsr.IsSuccess;
            if (ok)
            {
                DataSource.DS.User = retUsr.Data;
            }
            rs.Values["login"] = ok ? Username.Text : null;
            rs.Values["password"] = ok ? Password.Password : null;
            rs.Values["logged"] = ok;
            return ok;
        }

        private async void LoginButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Waiter.Visibility = Visibility.Visible;
            if (await DoLogin(Username.Text, Password.Password))
            {
                await RestApiManager.GetOwnedEvents();
                Frame.Navigate(typeof(MyEventList));
                return;
            }
            else
            {
                // Create the message dialog and set its content and title
                var messageDialog = new MessageDialog("Votre identifiant ou votre mot de passe est incorrect", "Erreur");

                //// Add commands and set their callbacks
                //messageDialog.Commands.Add(new UICommand("Don't install", (command) =>
                //{
                //    rootPage.NotifyUser("The 'Don't install' command has been selected.", NotifyType.StatusMessage);
                //}));

                //messageDialog.Commands.Add(new UICommand("Install updates", (command) =>
                //{
                //    rootPage.NotifyUser("The 'Install updates' command has been selected.", NotifyType.StatusMessage);
                //}));

                //// Set the command that will be invoked by default
                //messageDialog.DefaultCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();
                Waiter.Visibility = Visibility.Collapsed;
            }
        }
    }
}
