using Android.App;
using Android.Content;
using KodiAndroid.Entire;

namespace KodiAndroid.Logic.Service
{
    public class DataWorker
    {
        private readonly Activity _activity;
        private readonly Entire.Params _params = new Entire.Params();

        public DataWorker(Activity activity)
        {
            _activity = activity;
        }

        public void SavePreferences()
        {
            var prefs = _activity.GetSharedPreferences("Preferences", FileCreationMode.Private);
            var editor = prefs.Edit();
            editor.PutString(_params.UrlAdress, Settings.UrlAdress);
            editor.PutBoolean(_params.VibrationState, Settings.VibrationState);
            editor.Commit();
        }

        public void LoadPreferences()
        {

            var prefs = _activity.GetSharedPreferences("Preferences", FileCreationMode.Private);
            if (prefs.Contains(_params.UrlAdress))
            {
                Settings.UrlAdress = prefs.GetString(_params.UrlAdress, "127.0.0.1:8080");
            }
            if (prefs.Contains(_params.VibrationState))
            {
                Settings.VibrationState = prefs.GetBoolean(_params.VibrationState, false);
            }
        }

       
    }
}