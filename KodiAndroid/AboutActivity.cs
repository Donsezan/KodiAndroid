using Android.App;
using Android.Content.PM;
using Android.OS;
using KodiAndroid.ViewModels;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", Icon = "@drawable/kodi_logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.About);
            var aboutPageViewModel = new AboutPageViewModel(this);
            aboutPageViewModel.AboutPageActivity();
        }

    }
}