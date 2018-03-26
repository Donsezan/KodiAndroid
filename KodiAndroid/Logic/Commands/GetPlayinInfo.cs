using System.Collections.Generic;
using KodiAndroid.DataContracts;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class GetPlayinInfo : ResultObjectStrategy
    {
        public override RootObject CreateJson()
        {
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

            var jsParam = new Params { playerid = 1, properties = jsProperties };
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

        protected override List<string> AddAdditionalData(List<string> desList, JsonRpcReceivingApi.ResultObject rootObject)
        {
            var result = rootObject.result;
            desList.Add(result.item.label);
            desList.Add(result.item.thumbnail);
            return desList;
        }
    }
}