using System.ComponentModel;
using Xamarin.Forms;
using SCalendar.ViewModels;

namespace SCalendar.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
