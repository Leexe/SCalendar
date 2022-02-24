using Syncfusion.SfCalendar.XForms;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

using SCalendar.Models;
using System.Diagnostics;

namespace SCalendar.ViewModels
{
    public class AppointmentsViewModel : BaseViewModel
    {
        // Variables
        public CalendarEventCollection Events { get; set; } = new CalendarEventCollection();
        private ICommand _refresh;

        // Getters and Setters
        public ICommand Refresh
        {
            get
            {
                return _refresh;
            }
            set
            {
                _refresh = value;
                OnPropertyChanged("Refresh");
            }
        }

        // Constructors
        public AppointmentsViewModel()
        {
            CalendarInlineEvent event1 = SetEvent(2022, 2, 19, 21, 5, 9, Color.Accent, "Do HW");
            AddEvent(event1);
            CalendarInlineEvent event2 = SetEvent(2022, 2, 17, 24, 2, 22, Color.Aqua, "Code Game");
            AddEvent(event2);
            CalendarInlineEvent event3 = SetEvent(2022, 2, 19, 27, 5, 9, Color.Chartreuse, "Study For SAT");
            AddEvent(event3);

            Refresh = new Command(ExecuteRefresh);
        }

        // Methods
        // Creates an instance of an event
        public async void LoadItemIds(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                string Id = item.Id;
                string subject = item.Text;
                int EndingDate = item.EndingDate;
                int StartingDate = item.StartingDate;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public CalendarInlineEvent SetEvent(int years, int Month, int dayStart, int dayEnd,
               int start, int end, Color color, string subject)
        {
            CalendarInlineEvent events = new CalendarInlineEvent();
            events.StartTime = new DateTime(years, Month, dayStart, start, 0, 0);
            events.EndTime = new DateTime(years, Month, dayEnd, end, 0, 0);
            events.Subject = subject;
            events.Color = color;
            return events;
        }

        public async void AddToList(CalendarInlineEvent appointment)
        {
            string subject = appointment.Subject;
            string startTime = appointment.StartTime.ToString();
            string endTime = appointment.EndTime.ToString();

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = subject,
                Description = $"{startTime} - {endTime}"
            };

            await DataStore.AddItemAsync(newItem);
        }

        // Adds event to calender and list
        public void AddEvent(CalendarInlineEvent events)
        {
            Events.Add(events);
            AddToList(events);
        }

        // Refresh Calendar from ViewModel
        private void ExecuteRefresh(object obj)
        {
            if (obj is SfCalendar)
            {
                (obj as SfCalendar).Refresh();
            }
        }
    }
}
