using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public class VolumUp : ResultStringStrategy
    {
        public override RootObject CreateJson()
        {
            var jsParam = new DataContract.Params { volume = "increment" };
            var jsContract = new RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Application.SetVolume",
                @params = jsParam
            };
            return jsContract;
        }

        protected override bool ValidateData(JsonRpcReceivingApi.ResultString rootObject)
        {
            return (rootObject.id != 0 && rootObject.result != null && rootObject.jsonrpc != null);
        }

        public VolumUp(JsonService jsonService) : base(jsonService)
        {
        }
    }
}