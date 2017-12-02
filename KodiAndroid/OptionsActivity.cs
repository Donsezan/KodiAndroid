using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using KodiAndroid.Entire;
using KodiAndroid.Logic.Service;
using KodiAndroid.Resources;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", Icon = "@drawable/kodi_logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class OptionsActivity : Activity
    {
        private readonly DataWorker _data;

        public OptionsActivity()
        {
            _data = new DataWorker(this);
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Options);

            var tt = new TaskTracker();
            var urlField = FindViewById<EditText>(Resource.Id.ApiUnr);
            var vibraSwitch = FindViewById<Switch>(Resource.Id.VibraSwitch);
            var saveOptions = FindViewById<Button>(Resource.Id.SaveOptions);
            UpdateDisplay(urlField, vibraSwitch);

            

            tt.TaskCompleted += (sender, eventArgs) =>
            {
                if (!tt.AllCompleted)
                {
                    //UpdateText("Task in progress");
                }
                else
                {
                    //UpdateText("No Task in progress");
                }
            };
            tt.TaskStarted += (sender, e) =>
            {


            };

            saveOptions.Click += (sender, e) =>
            {
                tt.AddTask(Task.Factory.StartNew(() =>
                {
                    Settings.UrlAdress = urlField.Text;
                    Settings.VibrationState = vibraSwitch.Checked;
                    _data.SavePreferences();
                }, TaskCreationOptions.LongRunning));
            };
        }

        private void UpdateDisplay(EditText urlField, Switch vibraSwitch)
        {
            urlField.Text = Settings.UrlAdress;
            vibraSwitch.Checked = Settings.VibrationState;
        }


    }
}