using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using SCalendar.ViewModels;

namespace SCalendar.Views
{
    public partial class Calendar : ContentPage
    {
        public Calendar()
        {
            InitializeComponent();
        }

        // Triggers when the button is clicked
        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        async void View_Refreshing(System.Object sender, System.EventArgs e)
        {
            await Task.Delay(2500);
            refreshView.IsRefreshing = false;
        }
    }
}
