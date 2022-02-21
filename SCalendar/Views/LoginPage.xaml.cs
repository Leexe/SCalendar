using System;
using System.IO;
using Xamarin.Forms;

namespace SCalendar.Views
{ 
    public partial class LoginPage : ContentPage
    {
        // Notes code provided by https://docs.microsoft.com/en-us/xamarin/get-started/quickstarts/app?pivots=macos
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public LoginPage()
        {
            InitializeComponent();

            // Reads the file
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
                if (File.Exists(_fileName))
                {
                    editor.Text = File.ReadAllText(_fileName);
                }
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Save the file.
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Delete the file.
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }
    }
}
