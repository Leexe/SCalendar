using System;
using System.ComponentModel;
using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms.Xaml;

namespace SCalendar.Views
{
    public partial class Calendar : ContentPage
    {
        public CalendarEventCollection Events { get; set; } = new CalendarEventCollection();

        public Calendar()
        {
            InitializeComponent();
        }
    }
}
