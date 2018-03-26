using System.Collections.Generic;
using KodiAndroid.DataContracts;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class GoToNext : ResultStringStrategy
    {
        public override RootObject CreateJson()
        {
            var jsParam = new Params {playerid = 1, to = "next"};
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Player.GoTo",
                @params = jsParam
            };
            return jsContract;
        }

        protected override bool ValidateData(JsonRpcReceivingApi.ResultString rootObject)
        {
            return (rootObject.id != 0 && rootObject.result != null && rootObject.jsonrpc != null);
        }

        public GoToNext(JsonService jsonService) : base(jsonService)
        {
        }
    }
}