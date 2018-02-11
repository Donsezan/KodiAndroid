using KodiAndroid.DataContract;
using Newtonsoft.Json;

namespace KodiAndroid.Logic.Service
{
    public class JsonService 
    {
        public string Serelize(RootObject datacontract)
        {
            var jsonFile = JsonConvert.SerializeObject(datacontract, 
                Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            return jsonFile;
        }

        public JsonRpcReceivingApi.RootObject DeSerelize(string jsFile)
        {
            try
            {
                var jsonData = JsonConvert.DeserializeObject<JsonRpcReceivingApi.RootObject>(jsFile);
                return jsonData;
            }
            catch (JsonException)
            {

                return null;

            }
        }

    }
}