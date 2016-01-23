using Intense.Presentation;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using EventApp.Pages;
using EventApp.Presentation;
using EventApp.Service;

namespace EventApp
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            this.InitializeComponent();

            var vm = new ShellViewModel();
            
            vm.TopItems.Add(new NavigationItem { Icon = "\uE7C5", DisplayName = "My events", PageType = typeof(MyEventList) });
            vm.TopItems.Add(new NavigationItem { Icon = "\uE77B", DisplayName = "My account", PageType = typeof(MyAccount) });
            //vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Welcome", PageType = typeof(WelcomePage) });
            //vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Page 3", PageType = typeof(Page3) });

            vm.BottomItems.Add(new NavigationItem { Icon = "\uE8D7", DisplayName = "Authentication", PageType = typeof(Authentication) });
            vm.BottomItems.Add(new NavigationItem { Icon = "", DisplayName = "Settings", PageType = typeof(SettingsPage) });

            // select the first top item
            vm.SelectedItem = vm.BottomItems.First();

            this.ViewModel = vm;
        }

        public ShellViewModel ViewModel { get; private set; }

        public Frame RootFrame
        {
            get
            {
                return this.Frame;
            }
        }
    }
}
