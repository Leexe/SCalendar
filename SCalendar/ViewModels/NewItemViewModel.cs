using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SCalendar.Models;
using Xamarin.Forms;

namespace SCalendar.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string startingDate;
        private string endingDate;
        private string startingTime;
        private string endingTime;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(startingDate)
                && !String.IsNullOrWhiteSpace(startingTime)
                && !String.IsNullOrWhiteSpace(endingTime)
                && !String.IsNullOrWhiteSpace(endingDate);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string StartingDate
        {
            get => startingDate;
            set => SetProperty(ref startingDate, value);
        }

        public string EndingDate
        {
            get => endingDate;
            set => SetProperty(ref endingDate, value);
        }

        public string StartingTime
        {
            get => startingTime;
            set => SetProperty(ref startingTime, value);
        }

        public string EndingTime
        {
            get => endingTime;
            set => SetProperty(ref endingTime, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                StartingDate = int.Parse(StartingDate),
                EndingDate = int.Parse(EndingDate),
                StartingTime = int.Parse(StartingTime),
                EndingTime = int.Parse(EndingTime),
                Description = $"2/{StartingDate}/2022 {StartingTime}:00:00 AM - 2/{endingDate}/2022 {EndingTime}:00:00 PM"
            };

            ItemsCreated += 1;
            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
