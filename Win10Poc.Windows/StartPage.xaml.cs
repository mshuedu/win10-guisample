using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Win10Poc.Windows
{
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void Page1Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page1SplitView));
        }

        private void Page2Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page2RelativePanel));
        }

        private void Page3Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page3RelativePanel));
        }

        private void Page4Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page4LiveTile));
        }

        private void Page5Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page5ActionCenter));
        }

        private void Page6Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page6AppCalendar));
        }
    }
}
