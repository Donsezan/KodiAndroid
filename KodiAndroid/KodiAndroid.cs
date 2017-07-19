using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Provider;
using KodiAndroid.Logic;


namespace KodiAndroid
{
    public class KodiAndroid
    {
        public string Status;

        private IStrategy _strategy;
        private JsonSerializingMethod jsSerialMethod = new JsonSerializingMethod();

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

        public string SendPostReqest()
        {
            jsSerialMethod = new JsonSerializingMethod();
            var jsonData = _strategy.CreateJson();

            var jsFile = jsSerialMethod.Serelize(jsonData);
            var httpClentMethod = new HttpClientMethod();
            var status = httpClentMethod.PostReqest(jsFile, @"http://192.168.0.206:8080/jsonrpc");
            return status;
        }

        public string DeserilizeJson(string jsResponse)
        {
            return jsSerialMethod.DeSerelize(jsResponse);
        }
    }
}