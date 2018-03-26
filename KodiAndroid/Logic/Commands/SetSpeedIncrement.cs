﻿using System.Collections.Generic;
using KodiAndroid.DataContracts;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class SetSpeedIncrement : ResultObjectStrategy
    {
        public override RootObject CreateJson()
        {
            var jsParam = new Params {playerid = 1, speed = "increment"};
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
            if (rootObject.id != 0 && rootObject.jsonrpc != null && rootObject.result != null)
            {
                return (rootObject.result.speed >= 0 || rootObject.result.speed <= 10);
            }
            return false;
        }

        public SetSpeedIncrement(JsonService jsonService) : base(jsonService)
        {
        }

        protected override List<string> AddAdditionalData(List<string> desList, JsonRpcReceivingApi.ResultObject rootObject)
        {
            desList.Add($"Increment speed to: {rootObject.result.speed}");
            return desList;
        }
    }
}