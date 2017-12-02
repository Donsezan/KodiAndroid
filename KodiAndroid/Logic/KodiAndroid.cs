using KodiAndroid.Entire;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic
{
    public class KodiAndroid
    {
        public string Status;
        private readonly VibraService _vibra = new VibraService();

        private IStrategy _strategy;
        private JsonSerializingService _jsSerialMethod = new JsonSerializingService();

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
            _jsSerialMethod = new JsonSerializingService();
            var jsonData = _strategy.CreateJson();

            var jsFile = _jsSerialMethod.Serelize(jsonData);
            var httpClentMethod = new HttpClientMethod();
            var status = httpClentMethod.PostReqest(jsFile, @"http://"+Settings.UrlAdress+"/jsonrpc");
            return status;
        }

        public string DeserilizeJson(string jsResponse)
        {
            return _jsSerialMethod.DeSerelize(jsResponse);
        }
    }
}