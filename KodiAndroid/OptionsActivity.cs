﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using KodiAndroid.Entire;
using KodiAndroid.Logic.Service;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", Icon = "@drawable/kodi_logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class OptionsActivity : Activity
    {
        private readonly DataService _data;

        public OptionsActivity()
        {
            _data = new DataService(this);
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

            saveOptions.Click += (sender, e) =>
            {
                tt.AddTask(() =>
                {
                    Settings.UrlAdress = urlField.Text;
                    Settings.VibrationState = vibraSwitch.Checked;
                    _data.SavePreferences();
                });
                OnBackPressed();
            };
        }

        private void UpdateDisplay(TextView urlField, ICheckable vibraSwitch)
        {
            urlField.Text = Settings.UrlAdress;
            vibraSwitch.Checked = Settings.VibrationState;
        }
    }
}