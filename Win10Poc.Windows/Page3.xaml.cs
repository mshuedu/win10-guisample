using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
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
    public sealed partial class Page3 : Page
    {
        public Page3()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            Debug.WriteLine($"Window Width: {e.Size.Width} | Window Height: {e.Size.Height}");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) BackButton.Visibility = Visibility.Collapsed;

            SystemNavigationManager.GetForCurrentView().BackRequested += Page3_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= Page3_BackRequested;
        }

        private void Page3_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }
    }
}
