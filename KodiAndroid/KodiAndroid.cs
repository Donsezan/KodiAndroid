using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Provider;
using Newtonsoft.Json;


namespace KodiAndroid
{
    public class KodiAndroid
    {
        public string Status;

        public async Task PostRequests()
        {
            WebClient wc = new WebClient();
            string dataString = @"{""method"" : ""guru.test"", ""params"" : [ ""Guru"" ], ""id"" : 123 }";

            byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
            byte[] responseBytes = wc.UploadData(new Uri("https://gurujsonrpc.appspot.com/guru"), "POST", dataBytes);

            string responseString = Encoding.UTF8.GetString(responseBytes);
            Status = responseString;
        }
    }
}