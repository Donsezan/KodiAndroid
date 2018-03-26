using System.Collections.Generic;
using KodiAndroid.DataContracts;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public abstract class BaseStrategy<TType> : IBaseStrategy 
        where TType : JsonRpcReceivingApi.RootObject
    {
        private readonly JsonService _jsonService;

        protected BaseStrategy(JsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public abstract RootObject CreateJson();

        public abstract List<string> EncodeResponse(string response);

        protected TType Deserialize(string data)
        {
            return _jsonService.DeSerelize<TType>(data);
        }

        protected abstract bool ValidateData(TType data);
    }
}