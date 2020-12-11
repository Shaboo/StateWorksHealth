using StatWorks.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatWorks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BMIResult : ContentPage
    {
        public BMIResult()
        {
            InitializeComponent();
        }

        public BMIResult(BMIApiResponse result)
        {
            InitializeComponent();

            this.BindingContext = result;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.DeepPink;
        }
    }
}