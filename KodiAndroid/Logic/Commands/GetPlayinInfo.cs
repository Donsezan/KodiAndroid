using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class GetPlayinInfo : ResultObjectStrategy
    {
        public override RootObject CreateJson()
        {
            //var properties = new DataContract.Params().properties;
            //properties.Add("title");
            //properties.Add("season");
            //properties.Add("episode");
            //properties.Add("plot");
            //properties.Add("runtime");
            //properties.Add("showtitle");
            //properties.Add("thumbnail");

            var jsProperties = new List<string>
            {
                "title",
                "season",
                "episode",
                "plot",
                "runtime",
                "showtitle",
                "thumbnail"
            };

            var jsParam = new DataContract.Params { playerid = 1, properties = jsProperties };
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Player.GetItem",
                @params = jsParam
            };
            return jsContract;
        }

        protected override bool ValidateData(JsonRpcReceivingApi.ResultObject data)
        {
            var result = data.result;
            return !(
                data.id == 0 
                && data.jsonrpc == null 
                && result.item.thumbnail == null
                && result.item.label == null
            );
        }

        public GetPlayinInfo(JsonService jsonService) : base(jsonService)
        {
        }

        protected override void AddAdditionalData(List<string> desList, JsonRpcReceivingApi.ResultObject rootObject)
        {
            var result = rootObject.result;
            desList.Add(result.item.label);
            desList.Add(result.item.thumbnail);
        }
    }
}