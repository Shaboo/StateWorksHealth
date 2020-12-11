using StatWorks.Views;
using Xamarin.Forms;

namespace StatWorks
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BMI())
            {
                BarBackgroundColor = Color.BlueViolet
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
