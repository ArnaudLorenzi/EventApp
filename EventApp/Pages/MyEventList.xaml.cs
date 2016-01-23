using EventApp.Model;
using EventApp.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Windows.UI.Xaml.Shapes;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace EventApp.Pages
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MyEventList : Page
    {

        private ObservableCollection<GroupInfoList> groups;

        public MyEventList()
        {
            this.InitializeComponent();
            groups = new ObservableCollection<GroupInfoList>();
            foreach (var g in DataSource.DS.Events.GroupBy(ev => ev.Name[0]))
            {
                GroupInfoList info = new GroupInfoList();
                info.Key = g.Key;
                foreach (var item in g)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }
            Events.Source = groups;
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
        }
        
        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var evt = e.ClickedItem as Event;
            await RestApiManager.LoadEventPictures(evt);
            Frame.Navigate(typeof(MyEvent), evt);
        }

        private async void GridView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var evt = ((Ellipse)e.OriginalSource).DataContext as Event;
            await RestApiManager.LoadEventPictures(evt);
            Frame.Navigate(typeof(MyEvent), evt);
        }
    }
}
