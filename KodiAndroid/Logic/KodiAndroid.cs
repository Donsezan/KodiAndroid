using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic
{
    public class KodiAndroid
    {
        public string Status;
        private readonly VibraService _vibra = new VibraService();
        private readonly PostService _postService = new PostService();
        private readonly JsonService _jsonService = new JsonService();


        private IStrategy _strategy;

        public KodiAndroid(IStrategy strategy)
        {
            
            _strategy = strategy;

        }

        public KodiAndroid()
        {
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Vibrate(object activity)
        {
            _vibra.Vibrate(activity);
        }

        public string SendPostReqest()
        {
            var status = _postService.SendActionPostReqest(_strategy);
            return status;
        }

        public List<string> DeserilizeJsonToString(string jsResponse)
        {
            var response = _jsonService.DeSerelize(jsResponse);
            var responsetext = _strategy.EncodeResponse(response);
            return responsetext;
        }
    }
}