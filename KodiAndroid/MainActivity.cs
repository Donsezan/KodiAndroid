using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using KodiAndroid.Logic.Service;
using KodiAndroid.ViewModels;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", MainLauncher = true, Icon = "@drawable/kodi_logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private const int MyPermissionsRequest = 101;

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(OptionsActivity));
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnCreate(Bundle bundle)
        {
            var init = new DataService(this);
            var mainActivity = new MainPageViewModel(this);
            init.LoadPreferences();
            base.OnCreate(bundle);
            ReqestPremision();
            SetContentView(Resource.Layout.Main);
            mainActivity.MainViewActivity();
        }

        private void ReqestPremision()
    {
        if (CheckSelfPermission(Manifest.Permission.Internet) != Permission.Granted)
        {
            if (ShouldShowRequestPermissionRationale(Manifest.Permission.Internet))
            {
            }
            else
            {
                RequestPermissions(new[] {Manifest.Permission.Internet}, MyPermissionsRequest);
            }
        }
    }
    }
}

