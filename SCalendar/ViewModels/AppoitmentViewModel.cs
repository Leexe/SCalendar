using Syncfusion.SfCalendar.XForms;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SCalendar.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        // Variables
        public CalendarEventCollection Events { get; set; } = new CalendarEventCollection();
        public event PropertyChangedEventHandler PropertyChanged;
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

        // Constructor
        public AppointmentsViewModel()
        {
            CalendarInlineEvent event1 = SetEvent(2022, 2, 19, 21, 5, 9, "Get Advil");
            AddEvent(event1);
            CalendarInlineEvent event2 = SetEvent(2022, 2, 17, 24, 2, 22, "Code Game");
            AddEvent(event2);
            CalendarInlineEvent event3 = SetEvent(2022, 2, 19, 27, 5, 9, "Study For SAT");
            AddEvent(event3);

            Refresh = new Command(ExecuteRefresh);
        }

        // Methods
        // Creates an instance of an event
        public CalendarInlineEvent SetEvent(int years, int Month, int dayStart, int dayEnd,
               int start, int end, string subject)
        {
            CalendarInlineEvent events = new CalendarInlineEvent();
            events.StartTime = new DateTime(years, Month, dayStart, start, 0, 0);
            events.EndTime = new DateTime(years, Month, dayEnd, end, 0, 0);
            events.Subject = subject;
            events.Color = Color.Red;
            return events;
        }

        // Adds event to calender
        public void AddEvent(CalendarInlineEvent events)
        {
            Events.Add(events);
        }

        // Refresh Calendar from ViewModel
        private void ExecuteRefresh(object obj)
        {
            if (obj is SfCalendar)
            {
                (obj as SfCalendar).Refresh();
            }
        }

        // Checks for changes
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
