
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Gratitude.Data;
using Xamarin.Forms;

namespace Gratitude
{
    public partial class GratitudePage : ContentPage
    {
        //ToDo: Implement the INotifyPropertyChanged interface to support change of visibility.
        //ToDo: Move all the static text into the constants class.
        bool IsLoading = false;
        public GratitudePage()
        {
            InitializeComponent();
            setEventHandlers();
            Title = "Attitude of Gratitude";
        }

        protected async override void OnAppearing()
        {
            
            base.OnAppearing();
            if (Application.Current.Properties.ContainsKey(Constants.DATA_KEY_NAME))
            {
                var keyValue = Application.Current.Properties[Constants.DATA_KEY_NAME].ToString();
                if (keyValue == "0")
                    await loadData();
            }
            else
                await loadData();
        }

        private void setEventHandlers(){
            buttonDailyReflection.Clicked += OnButtonClicked;
        }

		void OnButtonClicked(object sender, EventArgs e)
		{
            try
            {
                Navigation.PushAsync(new DailyReflectionsPage(){Title="Daily Reflection"});
            }
            catch(Exception ex){
                Debug.WriteLine("Error:{0}\nMessage: {1}\nStackTrace: {2}", ex, ex.Message, ex.StackTrace);

            }
		}

        private async Task loadData(){
            try
            {
                IsLoading = true;
                var result = await Meeting.CreateDataBase(Constants.DB_FILE_PATH);
                if (result)
                {
                    buttonDailyReflection.IsEnabled = true;
                    buttonFindMeeting.IsEnabled = true;
                    buttonBrowseMeetings.IsEnabled = true;
                    buttonContactUs.IsEnabled = true;
                    Application.Current.Properties[Constants.DATA_KEY_NAME] = "1";
                    IsLoading = false;
                }
                else
                    Application.Current.Properties[Constants.DATA_KEY_NAME] = "0";
            }
            catch(Exception ex){
                Debug.WriteLine("Error: {0}\nMessage:{1}\nStackTrace:{2}", ex, ex.Message, ex.StackTrace);
                Application.Current.Properties[Constants.DATA_KEY_NAME] = "0";
            }
        }
    }
}
