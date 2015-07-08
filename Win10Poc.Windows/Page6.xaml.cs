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

namespace Win10Poc.Windows
{
    public sealed partial class Page6 : Page
    {
        public Page6()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            AppointmentStore store = await AppointmentManager.RequestStoreAsync(AppointmentStoreAccessType.AppCalendarsReadWrite);

            AppointmentCalendar calendar;
            var calendars = await store.FindAppointmentCalendarsAsync();
            if (!calendars.Any(i => i.DisplayName == "SampleCalendar"))
            {
                calendar = await store.CreateAppointmentCalendarAsync("SampleCalendar");
            }
            else
            {
                calendar = calendars.First(i => i.DisplayName == "SampleCalendar");
            }

            await calendar.SaveAppointmentAsync(
                new Appointment()
                {
                    Subject = "SampleEvent",
                    StartTime = DateTime.Now,
                    Duration = TimeSpan.FromHours(1)
                });

            base.OnNavigatedTo(e);
        }
    }
}
