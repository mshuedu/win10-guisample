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
    public sealed partial class Page5ActionCenter : Page
    {
        public Page5ActionCenter()
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

        private void btnNotif_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var content = @"<toast>
                              <visual>
                                <binding template='ToastGeneric'>
                                  <text>Cat Cuteness Competition</text>
                                  <text>Check out this kitten!</text>
                                  <image placement='inline' src='http://2.bp.blogspot.com/_6rROSHI_zZ4/SfY4yPxlHFI/AAAAAAAABpY/0iPyrZOreHc/S220/cat_avatar_0065_www.free-avatars.com.jpg' />
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
                                  <text>Cat Cuteness Competition</text>
                                  <text>Please rate our cat!</text>
                                  <image placement='inline' src='http://2.bp.blogspot.com/_6rROSHI_zZ4/SfY4yPxlHFI/AAAAAAAABpY/0iPyrZOreHc/S220/cat_avatar_0065_www.free-avatars.com.jpg' />
                                </binding>
                              </visual>
                              <actions>
                                <action activationType='foreground' arguments='cat-cute' content='Cute' />
                                <action activationType='foreground' arguments='cat-ugly' content='Ugly' />
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
                                  <text>Cat Cuteness Competition</text>
                                  <text>What is your opinion of this cat?</text>
                                  <image placement='inline' src='http://2.bp.blogspot.com/_6rROSHI_zZ4/SfY4yPxlHFI/AAAAAAAABpY/0iPyrZOreHc/S220/cat_avatar_0065_www.free-avatars.com.jpg' />
                                </binding>
                              </visual>
                              <actions>
                                <input id='message' type='text' placeholderContent='I find this cat...' />
                                <action activationType='foreground' content='Send' arguments='cat-opinion' />
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
