using EventApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EventApp.UserControls
{
    public sealed partial class EventAppPane : UserControl
    {
        public EventAppPane()
        {
            //this.InitializeComponent();
        }
        //private void NavigateToOptimized(object sender, RoutedEventArgs e)
        //{
        //    ((Frame)Window.Current.Content).Navigate(typeof(SimpleListViewSample));
        //}
        //private void NavigateToOptimizedGrid(object sender, RoutedEventArgs e)
        //{
        //    ((Frame)Window.Current.Content).Navigate(typeof(SimpleGridViewSample));
        //}
        //private void NavigateToMasterDetailSelection(object sender, RoutedEventArgs e)
        //{
        //    ((Frame)Window.Current.Content).Navigate(typeof(MasterDetailSelection));
        //}
        //private void NavigateToEdgeTappedListView(object sender, RoutedEventArgs e)
        //{
        //    ((Frame)Window.Current.Content).Navigate(typeof(TapOnTheEdgeSample));
        //}
        //private void NavigateToRestoreScrollPosition(object sender, RoutedEventArgs e)
        //{
        //    ((Frame)Window.Current.Content).Navigate(typeof(RestoreScrollPositionSample));
        //}
        private void NavigateToHome(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(WelcomePage));
        }
    }
}