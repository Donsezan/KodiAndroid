using Android.App;
using Android.Widget;
using KodiAndroid.Entire;

namespace KodiAndroid.ViewModels
{
    public class AboutPageViewModel
    {
        private readonly Activity _activity;
        private readonly Params _params = new Params();
        public AboutPageViewModel(Activity activity)
        {
            _activity = activity;
        }

        public void AboutPageActivity()
        {
            var urlField = _activity.FindViewById<TextView>(Resource.Id.aboutToolbarText);
            urlField.Text = $"About {_params.AppName} ver: {_params.AppVersion}";
        }

    }
}