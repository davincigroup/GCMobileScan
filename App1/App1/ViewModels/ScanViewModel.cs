using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

 

namespace App1.ViewModels
{
    public class ScanViewModel : ContentView
    {
        public ScanViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}