using Android.App;
using Android.Content;
using Android.OS;
using KodiAndroid.Entire;

namespace KodiAndroid.Logic.Service
{
    public class VibraService
    {
        public void Vibrate(object active)
        {
            if (Settings.VibrationState)
            {
                var activity = (Activity)active;
                var vibrator = (Vibrator)activity.GetSystemService(Context.VibratorService);
                vibrator.Vibrate(30);
            }
          
        }
        
    }
}