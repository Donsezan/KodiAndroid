using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class Back : ResultStringStrategy
    {
        public override RootObject CreateJson()
        {
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Input.Back",
                @params = null
            };
            return jsContract;
        }

        protected override bool ValidateData(JsonRpcReceivingApi.ResultString rootObject)
        {
            return (rootObject.id != 0 && rootObject.result != null && rootObject.jsonrpc != null);
        }

        public Back(JsonService jsonService) : base(jsonService)
        {
        }
    }
}