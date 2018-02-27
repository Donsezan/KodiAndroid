using Android.App;
using Android.Content;
using Android.OS;
using KodiAndroid.Entire;

namespace KodiAndroid.Logic.Service
{
    public class VibraService
    {
        public void Vibrate(Activity activity)
        {
            if (Settings.VibrationState)
            {
                var vibrator = (Vibrator)activity.GetSystemService(Context.VibratorService);
                vibrator.Vibrate(30);
            }
          
        }
        
    }
}