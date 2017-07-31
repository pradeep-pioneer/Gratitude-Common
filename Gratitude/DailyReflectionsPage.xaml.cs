using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace Gratitude
{
    
    public partial class DailyReflectionsPage : ContentPage, INotifyPropertyChanged
    {
        bool isLoading = false;
        public string Url { get { return "https://www.aa.org/pages/en_US/daily-reflection"; } }
        public bool IsLoading
        {
            get { return isLoading; }
            set{
                isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }
        public DailyReflectionsPage()
        {
            IsLoading = true;
            InitializeComponent();
            webViewReflectionBrowser.Navigated += WebViewNavigated;
        }

        protected override void OnAppearing(){
			//webViewReflectionBrowser.Source = "https://www.aa.org/pages/en_US/daily-reflection";
		}

        private void WebViewNavigated(object source, EventArgs args){
            Debug.WriteLine("Navigated!");
            webViewReflectionBrowser.Eval("window.scrollTo(0, 550)");
            IsLoading = false;
        }
    }
}
