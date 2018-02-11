using KodiAndroid.DataContract;
using KodiAndroid.Entire;

namespace KodiAndroid.Logic.Service
{
    public class PostService
    {
        private readonly JsonService _jsonService = new JsonService();
        
        public string SendActionPostReqest(IStrategy strategy)
        {
            return SendReqest(strategy.CreateJson());
        }

        public string SendPostReqest(RootObject json)
        {
            return SendReqest(json);
        }

        private string SendReqest(RootObject rootObject)
        {
            var jsFile = _jsonService.Serelize(rootObject);
            var httpClentMethod = new HttpClientMethod();
            var response = httpClentMethod.PostReqest(jsFile, GetUrl());
            return response;
        }

        private string GetUrl()
        {
            var url = @"http://" + Settings.UrlAdress + "/jsonrpc";
            return url;
        }

    }
}