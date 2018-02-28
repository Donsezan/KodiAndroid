﻿using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class SetSpeedIncrement : ResultObjectStrategy
    {
        public override RootObject CreateJson()
        {
            var jsParam = new DataContract.Params {playerid = 1, speed = "increment"};
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Player.SetSpeed",
                @params = jsParam
            };
            return jsContract;
        }
        protected override bool ValidateData(JsonRpcReceivingApi.ResultObject rootObject)
        {
            return !(rootObject.id == 0 && rootObject.result == null && rootObject.jsonrpc == null );
        }

        public SetSpeedIncrement(JsonService jsonService) : base(jsonService)
        {
        }

        protected override void AddAdditionalData(List<string> desList, JsonRpcReceivingApi.ResultObject rootObject)
        {
            desList.Add($"Increment speed to: {rootObject.result.speed}");
        }
    }
}