using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.ApplicationModel;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using System.Threading.Tasks;

namespace Win10Poc.Windows
{
    public sealed partial class Page6AppCalendar : Page
    {
        private AppointmentCalendar calendar;

        public Page6AppCalendar()
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
            SystemNavigationManager.GetForCurrentView().BackRequested += Page6AppCalendar_BackRequested; ;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= Page6AppCalendar_BackRequested;
        }

        private void Page6AppCalendar_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        private async void CreateCalendarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await CreateOrOpenCalendarAsync();
        }

        private async void AddEventButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await AddSampleEventAsync();
        }

        private async Task CreateOrOpenCalendarAsync()
        {
            const string _calendarName = "Sample Calendar";

            AppointmentStore store = await AppointmentManager.RequestStoreAsync(AppointmentStoreAccessType.AppCalendarsReadWrite);

            var calendars = await store.FindAppointmentCalendarsAsync();
            if (!calendars.Any(i => i.DisplayName == _calendarName))
            {
                calendar = await store.CreateAppointmentCalendarAsync(_calendarName);
            }
            else
            {
                calendar = calendars.First(i => i.DisplayName == _calendarName);
            }
        }

        private async Task AddSampleEventAsync()
        {
            if (calendar == null) await CreateOrOpenCalendarAsync();

            await calendar.SaveAppointmentAsync(
                new Appointment()
                {
                    Subject = "Sample Event",
                    StartTime = DateTime.Now,
                    Duration = TimeSpan.FromHours(1)
                });
        }
    }
}
