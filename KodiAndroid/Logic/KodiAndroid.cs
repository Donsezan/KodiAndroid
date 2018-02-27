using Android.App;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic
{
    public class KodiAndroid
    {
        public string Status;
        private readonly VibraService _vibra = new VibraService();
        private readonly PostService _postService = new PostService();

        private IBaseStrategy _strategy;

        public void SetStrategy(IBaseStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Vibrate(Activity activity)
        {
            _vibra.Vibrate(activity);
        }

        public string SendPostReqest()
        {
            var status = _postService.SendActionPostReqest(_strategy);
            return status;
        }
    }
}