using System.Collections.Generic;
using Android.App;
using KodiAndroid.DataContract;
using Newtonsoft.Json;

namespace KodiAndroid.Logic.Service
{
    public class JsonService 
    {
        public string Serelize(RootObject datacontract)
        {
            var jsonFile = JsonConvert.SerializeObject(datacontract, 
                Formatting.Indented, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                    
                });
            return jsonFile;
        }

        public JsonRpcReceivingApi.RootObject DeSerelize(string jsFile)
        {
            try
            {
                var jsonData = JsonConvert.DeserializeObject<JsonRpcReceivingApi.RootObject>(jsFile);

                //if (jsonData.result.GetType() != typeof(string) & jsonData.result.GetType() != typeof(long))
                //{
                //    jsonData.result = JsonConvert.DeserializeObject<JsonRpcReceivingApi.Result>(jsonData.result.ToString());
                //}
                return jsonData;
            }
            catch (JsonException)
            {

                return null;

            }
        }
    }
}