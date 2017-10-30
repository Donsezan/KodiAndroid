using KodiAndroid.Logic;


namespace KodiAndroid
{
    public class KodiAndroid
    {
        public string Status;
        private readonly VibraService _vibra = new VibraService();

        private IStrategy _strategy;
        private JsonSerializingMethod _jsSerialMethod = new JsonSerializingMethod();

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
            _jsSerialMethod = new JsonSerializingMethod();
            var jsonData = _strategy.CreateJson();

            var jsFile = _jsSerialMethod.Serelize(jsonData);
            var httpClentMethod = new HttpClientMethod();
            var status = httpClentMethod.PostReqest(jsFile, @"http://192.168.0.206:8080/jsonrpc");
            return status;
        }

        public string DeserilizeJson(string jsResponse)
        {
            return _jsSerialMethod.DeSerelize(jsResponse);
        }
    }
}