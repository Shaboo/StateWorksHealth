using StatWorks.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatWorks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BMI : ContentPage
    {
        BMIViewModel viewModel;
        public BMI()
        {
            InitializeComponent();

            this.entWeight.Completed += EntWeight_Completed;
            this.entHeight.Completed += EntHeight_Completed;
            this.entAge.Completed += EntAge_Completed;
            this.entWaist.Completed += EntWaist_Completed;
            this.entHip.Completed += EntHip_Completed;

            viewModel = new BMIViewModel();
            this.BindingContext = viewModel;
        }

        private void EntWeight_Completed(object sender, System.EventArgs e)
        {
            this.entHeight.Focus();
        }

        private void EntHeight_Completed(object sender, System.EventArgs e)
        {
            this.entAge.Focus();
        }

        private void EntAge_Completed(object sender, System.EventArgs e)
        {
            this.entWaist.Focus();
        }

        private void EntWaist_Completed(object sender, System.EventArgs e)
        {
            this.entHip.Focus();
        }

        private void EntHip_Completed(object sender, System.EventArgs e)
        {
            this.btnSubmit.Command.Execute(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.BlueViolet;
        }
    }
}