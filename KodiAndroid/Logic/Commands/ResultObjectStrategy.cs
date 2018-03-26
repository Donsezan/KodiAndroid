using System.Collections.Generic;
using KodiAndroid.DataContracts;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public abstract class ResultObjectStrategy: BaseStrategy<JsonRpcReceivingApi.ResultObject>
    {
        public override List<string> EncodeResponse(string data)
        {
            var rootObject = Deserialize(data);
            var stringList = new List<string>();
            
            if (ValidateData(rootObject))
            {
                stringList = AddAdditionalData(stringList,rootObject);
                return stringList;
            }
            stringList.Add(StartegyResultParse.ErrorMesage);
            return stringList;
        }

        protected abstract List<string> AddAdditionalData(List<string> desList, JsonRpcReceivingApi.ResultObject rootObject);
        

        protected ResultObjectStrategy(JsonService jsonService) : base(jsonService)
        {
        }
    }
}