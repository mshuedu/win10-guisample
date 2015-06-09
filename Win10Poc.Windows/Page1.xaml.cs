using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Win10Poc.Windows
{
    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) BackButton.Visibility = Visibility.Collapsed;

            SystemNavigationManager.GetForCurrentView().BackRequested += Page1_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= Page1_BackRequested;
        }

        private void Page1_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }

        private void CompactOverlayButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainSplitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }

        private void CompactInlineButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainSplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
        }

        private void InlineButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainSplitView.DisplayMode = SplitViewDisplayMode.Inline;
        }

        private void OverlayButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainSplitView.DisplayMode = SplitViewDisplayMode.Overlay;
        }
    }
}
