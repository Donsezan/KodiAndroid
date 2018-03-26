using Android.App;
using Android.Content.PM;
using Android.OS;
using KodiAndroid.ViewModels;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", Icon = "@drawable/kodi_logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class OptionsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Options);
            var optionPageViewModel = new OptionPageViewModel(this);
            optionPageViewModel.OptionPageActivity();
        }
    }
}