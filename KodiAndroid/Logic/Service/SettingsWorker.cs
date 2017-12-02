using System;
using Android.App;
using Android.Content;

namespace KodiAndroid.Logic.Service
{
    public class SettingsWorker
    {
        public void Saveset(string key, string value)
        {

            //store
            var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();

        }

        // Function called from OnCreate
        public string Retrieveset(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            //retreive 
            var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            var somePref = prefs.GetString(key, null);
            return somePref;


        }
    }
}