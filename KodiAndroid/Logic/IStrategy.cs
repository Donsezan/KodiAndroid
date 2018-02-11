using System.Collections.Generic;
using KodiAndroid.DataContract;

namespace KodiAndroid.Logic
{
    public interface IStrategy
    {
        RootObject CreateJson();
        List<string> EncodeResponse(JsonRpcReceivingApi.RootObject data);
        bool ValidateData(JsonRpcReceivingApi.RootObject data);
    }
}