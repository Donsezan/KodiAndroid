using System;
using System.Net;
using System.Text;

namespace KodiAndroid.Logic.Service
{
    public class HttpClientService
    {
        public string PostReqest(string file, string url)
        {
            var wc = new WebClient();
            string responseString;
            try
            {
                var dataBytes = Encoding.UTF8.GetBytes(file);
                var responseBytes = wc.UploadData(new Uri(url), "POST", dataBytes);
                responseString = Encoding.UTF8.GetString(responseBytes);
            }
            catch (WebException ex)
            {
                if (ex.Status != WebExceptionStatus.ProtocolError)
                {
                    responseString = ex.Message;
                }
                else
                {
                    responseString = "Status Code : " + ((HttpWebResponse) ex.Response).StatusCode +
                                     "Status Description " + ((HttpWebResponse) ex.Response).StatusDescription;
                }
            }
            finally
            {
                wc.Dispose();
            }
            return responseString;
        }
    }
}