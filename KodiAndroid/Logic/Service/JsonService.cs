using KodiAndroid.DataContracts;
using Newtonsoft.Json;

namespace KodiAndroid.Logic.Service
{
    public class JsonService 
    {
        public string Serialize(RootObject datacontract)
        {
            var jsonFile = JsonConvert.SerializeObject(datacontract, 
                Formatting.None, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
            return jsonFile;
        }

        public T DeSerelize<T>(string jsFile)
            where T : JsonRpcReceivingApi.RootObject
        {
            try
            {
                var jsonData = JsonConvert.DeserializeObject<T>(jsFile);
                return jsonData;
            }
            catch
            {
                StartegyResultParse.ErrorMesage = jsFile;
                return null;
            }
        }
    }
}