using Xamarin.Forms;

namespace Gratitude
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new GratitudePage();
            MainPage = new NavigationPage(page) { BarBackgroundColor = (Color)this.Resources["barBackgroundColor"], BarTextColor=(Color)this.Resources["backgroundColor"]};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
