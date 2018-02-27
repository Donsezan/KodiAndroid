using KodiAndroid.DataContract;
using KodiAndroid.Entire;

namespace KodiAndroid.Logic.Service
{
    public class PostService
    {
        private readonly JsonService _jsonService = new JsonService();
        public string SendActionPostReqest(IBaseStrategy strategy)
        {
            return SendReqest(strategy.CreateJson());
        }

        private string SendReqest(RootObject rootObject)
        {
            var url = @"http://" + Settings.UrlAdress + "/jsonrpc";
            var jsFile = _jsonService.Serialize(rootObject);
            var httpClientService = new HttpClientService();
            //var httpClientService = new HttpStubService();

            var response = httpClientService.PostReqest(jsFile, url);
            return response;
        }

    }
}