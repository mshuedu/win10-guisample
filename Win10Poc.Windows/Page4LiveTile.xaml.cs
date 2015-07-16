using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Win10Poc.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page4LiveTile : Page
    {
        private const string tileId = "w10poc-secondary-tile";

        public Page4LiveTile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            SystemNavigationManager.GetForCurrentView().BackRequested += Page4_BackRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= Page4_BackRequested;
        }

        private void Page4_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        private async void PinTileButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SecondaryTile tile = new SecondaryTile(
                tileId,
                "Win10 POC Secondary Tile",
                "nothing",
                new Uri("ms-appx:///Assets/WideLogo.png"),
                TileSize.Wide310x150);
            await tile.RequestCreateAsync();
            tile.VisualElements.Square150x150Logo = new Uri("ms-appx:///Assets/Logo.png");
            tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/WideLogo.png");
        }

        private void UpdateTileButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForSecondaryTile(tileId);
            var doc = new XmlDocument();
            doc.LoadXml(
            "<tile version='3'>" +
                "<visual>" +
                    "<binding template='TileMedium' branding='None'>" +
                        "<group>" +
                            "<subgroup>" +
                                "<text hint-style='Body' hint-wrap='true'>You have mail</text>" +
                                $"<text hint-style='Caption' hint-wrap='true'>{DateTime.Now.ToString()}</text>" +
                            "</subgroup>" +
                        "</group>" +
                    "</binding>" +
                    "<binding template='TileWide' branding='None'>" +
                        "<group>" +
                            "<subgroup hint-weight='40'>" +
                                "<image placement='Inline' src='http://fc02.deviantart.net/fs71/i/2013/359/a/4/deadpool_logo_1_fill_by_mr_droy-d5q6y5u.png' />" +
                            "</subgroup>" +
                            "<subgroup>" +
                                "<text hint-style='Body' hint-wrap='true'>You have mail</text>" +
                                $"<text hint-style='Caption' hint-wrap='true'>{DateTime.Now.ToString()}</text>" +
                            "</subgroup>" +
                        "</group>" +
                    "</binding>" +
                "</visual>" +
            "</tile>"
            );
            tileUpdater.Update(new TileNotification(doc));
        }
    }
}
