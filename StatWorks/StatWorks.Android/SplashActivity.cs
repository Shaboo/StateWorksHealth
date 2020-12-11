using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;

namespace StatWorks.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        private async void SimulateStartup()
        {
            var act = await Task.Run(() => new Intent(Application.Context, typeof(MainActivity)));

            StartActivity(act);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}