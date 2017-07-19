﻿using KodiAndroid.DataContract;
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

        public string DeSerelize(string jsFile)
        {
            try
            {
                var jsonData = JsonConvert.DeserializeObject<RootObject>(jsFile);
                if (jsonData.method != null)
                {
                    return jsonData.method;
                }
                return jsFile;
            }
            catch(JsonException)
            {
                return jsFile;
            }
        }

    }
}