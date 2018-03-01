using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class Down : ResultStringStrategy
    {
        public override RootObject CreateJson()
        {
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Input.Down",
                @params = null
            };
            return jsContract;
        }

        protected override bool ValidateData(JsonRpcReceivingApi.ResultString rootObject)
        {
            return (rootObject.id != 0 && rootObject.result != null && rootObject.jsonrpc != null);
        }

        public Down(JsonService jsonService) : base(jsonService)
        {
        }
    }
}