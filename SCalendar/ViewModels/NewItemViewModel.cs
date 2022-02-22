using System;
using SCalendar.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SCalendar.ViewModels
{
    public class NewItemViewModel : INotifyPropertyChanged
    {
        private string year;
        private string month;
        private string starting_date;
        private string ending_date;
        private string starting_time;
        private string ending_time;
        private string subject;

        public event PropertyChangedEventHandler PropertyChanged;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(year)
                && !String.IsNullOrWhiteSpace(month)
                && !String.IsNullOrWhiteSpace(starting_date)
                && !String.IsNullOrWhiteSpace(ending_date)
                && !String.IsNullOrWhiteSpace(starting_time)
                && !String.IsNullOrWhiteSpace(ending_time)
                && !String.IsNullOrWhiteSpace(subject);
        }

        public string Year
        {
            get => Year;
            set
            {
                if(year == value)
                    return;
                year = value;
                OnStringChanged(Year); 
            }
        }

        public string Month
        {
            get => Month;
            set
            {
                if (month == value)
                    return;
                month = value;
                OnStringChanged(Month);
            }
        }

        public string Starting_Date
        {
            get => Starting_Date;
            set
            {
                if (starting_date == value)
                    return;
                starting_date = value;
                OnStringChanged(Starting_Date);
            }
        }

        public string Ending_Date
        {
            get => Ending_Date;
            set
            {
                if (ending_date == value)
                    return;
                ending_date = value;
                OnStringChanged(Ending_Date);
            }
        }

        public string Starting_Time
        {
            get => Starting_Time;
            set
            {
                if (starting_time == value)
                    return;
                starting_time = value;
                OnStringChanged(Starting_Time);
            }
        }

        public string Ending_Time
        {
            get => Ending_Time;
            set
            {
                if (ending_time == value)
                    return;
                ending_time = value;
                OnStringChanged(Ending_Time);
            }
        }

        public string Subject
        {
            get => Subject;
            set
            {
                if (subject == value)
                    return;
                subject = value;
                OnStringChanged(Subject);
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        void OnStringChanged(string str)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
