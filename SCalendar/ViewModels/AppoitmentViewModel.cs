using System;
using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;

namespace SCalendar.ViewModels
{
    public class AppointmentsViewModel
    {
        public CalendarEventCollection Events { get; set; } = new CalendarEventCollection();

        public AppointmentsViewModel()
        {
            CalendarInlineEvent event1 = new CalendarInlineEvent();
            event1.StartTime = new DateTime(2022, 2, 11, 5, 0, 0);
            event1.EndTime = new DateTime(2022, 2, 21, 9, 0, 0);
            event1.Subject = "Go to Meeting";
            event1.Color = Color.Fuchsia;

            CalendarInlineEvent event2 = new CalendarInlineEvent();
            event2.StartTime = new DateTime(2022, 2, 19, 9, 0, 0);
            event2.EndTime = new DateTime(2022, 2, 19, 12, 0, 0);
            event2.Subject = "Go to Meeting";
            event2.Color = Color.Green;

            Events.Add(event1);
            Events.Add(event2);
        }
    }
}
