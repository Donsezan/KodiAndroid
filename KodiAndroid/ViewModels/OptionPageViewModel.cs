using Android.App;
using Android.Widget;
using KodiAndroid.Entire;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.ViewModels
{
    public class OptionPageViewModel
    {
        private readonly Activity _activity;
        private readonly DataService _data;
        public OptionPageViewModel(Activity activity)
        {
            _activity = activity;
            _data = new DataService(_activity);
        }

        private void UpdateDisplay(TextView urlField, ICheckable vibraSwitch)
        {
            urlField.Text = Settings.UrlAdress;
            vibraSwitch.Checked = Settings.VibrationState;
        }

        public void OptionPageActivity()
        {
            var tt = new TaskTracker();
            var urlField = _activity.FindViewById<EditText>(Resource.Id.ApiUnr);
            var vibraSwitch = _activity.FindViewById<Switch>(Resource.Id.VibraSwitch);
            var saveOptions = _activity.FindViewById<Button>(Resource.Id.SaveOptions);
            UpdateDisplay(urlField, vibraSwitch);

            saveOptions.Click += (sender, e) =>
            {
                tt.AddTask(() =>
                {
                    Settings.UrlAdress = urlField.Text;
                    Settings.VibrationState = vibraSwitch.Checked;
                    _data.SavePreferences();
                });
                _activity.OnBackPressed();
            };
        }
    }
}