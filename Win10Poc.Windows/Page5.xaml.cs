using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Notifications;
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
    public sealed partial class Page5 : Page
    {
        public Page5()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) BackButton.Visibility = Visibility.Collapsed;

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

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }

        private void btnNotif_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var content = @"<toast>
                              <visual>
                                <binding template='ToastGeneric'>
                                  <image placement='appLogoOverride' src='http://www.lairweb.org.nz/tiger/andeanmountaincat.jpg' />
                                  <text>Torrance Shum</text>
                                  <text>Media content attached.</text>
                                  <image placement='inline' src='http://2.bp.blogspot.com/_6rROSHI_zZ4/SfY4yPxlHFI/AAAAAAAABpY/0iPyrZOreHc/S220/cat_avatar_0065_www.free-avatars.com.jpg' />
                                  <text>Hey check out this photo. Isn’t it awesome?</text>
                                </binding>
                              </visual>
                            </toast>";
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(content);
            ToastNotification notif = new ToastNotification(xmldoc);
            var notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(notif);
        }

        private void btnNotifWithButtons_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var content = @"<toast>
                              <visual>
                                <binding template='ToastGeneric'>
                                  <image placement='appLogoOverride' src='http://www.lairweb.org.nz/tiger/andeanmountaincat.jpg' />
                                  <text>Torrance Shum</text>
                                  <text>Media content attached.</text>
                                  <image placement='inline' src='http://2.bp.blogspot.com/_6rROSHI_zZ4/SfY4yPxlHFI/AAAAAAAABpY/0iPyrZOreHc/S220/cat_avatar_0065_www.free-avatars.com.jpg' />
                                  <text>Hey check out this photo. Isn’t it awesome?</text>
                                </binding>
                              </visual>
                              <actions>
                                <action activationType='system' arguments='snooze'  content='' />
                                <action activationType='system' arguments='dismiss' content='' />
                              </actions>
                            </toast>";
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(content);
            ToastNotification notif = new ToastNotification(xmldoc);
            var notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(notif);
        }

        private void btnNotifWithTextBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var content = @"<toast>
                              <visual>
                                <binding template='ToastGeneric'>
                                  <image placement='appLogoOverride' src='http://www.lairweb.org.nz/tiger/andeanmountaincat.jpg' />
                                  <text>Torrance Shum</text>
                                  <text>Media content attached.</text>
                                  <image placement='inline' src='http://2.bp.blogspot.com/_6rROSHI_zZ4/SfY4yPxlHFI/AAAAAAAABpY/0iPyrZOreHc/S220/cat_avatar_0065_www.free-avatars.com.jpg' />
                                  <text>Hey check out this photo. Isn’t it awesome?</text>
                                </binding>
                              </visual>
                              <actions>
                                <input id='1' type='text' />
                                <action activationType='background' arguments='quickReply' hint-inputId='1' content='' imageUri='http://images.clipartof.com/thumbnails/1083261-Clipart-3d-Blue-Send-Button-Royalty-Free-CGI-Illustration.jpg' />
                              </actions>     
                            </toast>";
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(content);
            ToastNotification notif = new ToastNotification(xmldoc);
            var notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(notif);
        }
    }
}
