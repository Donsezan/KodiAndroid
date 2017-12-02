using Android.App;
using Android.Content;
using Android.OS;

namespace KodiAndroid.Logic.Service
{
    public class VibraService
    {
        public void Vibrate(object active)
        {
            
            var activity = (Activity)active;
            var vibrator = (Vibrator)activity.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(30);
        }
        
    }
}