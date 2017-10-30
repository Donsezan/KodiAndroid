using System;
using System.Net;
using System.Text;

namespace KodiAndroid.Logic
{
    public class HttpClientMethod
    {
        public string PostReqest(string file, string url)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var dataBytes = Encoding.UTF8.GetBytes(file);
                    var responseBytes = wc.UploadData(new Uri(url), "POST", dataBytes);
                    var responseString = Encoding.UTF8.GetString(responseBytes);
                    return responseString;
                }
            }
            catch (WebException ex)
            {
                if (ex.Status != WebExceptionStatus.ProtocolError) return ex.Message;
                var description = "Status Code : "+ ((HttpWebResponse)ex.Response).StatusCode + "Status Description "+ ((HttpWebResponse)ex.Response).StatusDescription;
                return description;
            }            
        }
        
    }
}