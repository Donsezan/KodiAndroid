using System;
using Android.App;
using Android.Content;

namespace KodiAndroid.Logic.Service
{
    public class SettingsWorker
    {
        private readonly string _appName;
        public SettingsWorker(string appName)
        {
            _appName = appName;
        }

        public void Saveset(string key, string value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var prefs = Application.Context.GetSharedPreferences(_appName, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();

        }
        
        public string Retrieveset(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var prefs = Application.Context.GetSharedPreferences(_appName, FileCreationMode.Private);
            var somePref = prefs.GetString(key, null);
            return somePref;


        }
    }
}