using KodiAndroid.DataContract;
using Newtonsoft.Json;

namespace KodiAndroid.Logic
{
    public class JsonSerializingMethod 
    {
        public string Serelize(RootObject datacontract)
        {
            var jsonFile = JsonConvert.SerializeObject(datacontract, 
                Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            return jsonFile;
        }
    }
}