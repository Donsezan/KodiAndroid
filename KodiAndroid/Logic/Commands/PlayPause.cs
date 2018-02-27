using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class PlayPause : ResultObjectStrategy
    {
        public override RootObject CreateJson()
        {
            var jsParam = new DataContract.Params {playerid = 1};
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Player.PlayPause",
                @params = jsParam
            };
            return jsContract;
        }

        protected override bool ValidateData(JsonRpcReceivingApi.ResultObject rootObject)
        {
            return rootObject.result == null && rootObject.jsonrpc == null;
        }

        public PlayPause(JsonService jsonService) : base(jsonService)
        {
        }

        protected override void AddAdditionalData(List<string> desList, JsonRpcReceivingApi.ResultObject rootObject)
        {
            desList.Add(rootObject.result.speed == 0 ? "Pause" : "Play");
        }
    }
}