using System.Collections.Generic;
using KodiAndroid.DataContract;
using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic.Commands
{
    public abstract class ResultStringStrategy : BaseStrategy<JsonRpcReceivingApi.ResultString>
    {
        protected ResultStringStrategy(JsonService jsonService):
            base(jsonService)
        {
        }

        public override List<string> EncodeResponse(string response)
        {
            var data = Deserialize(response);

            var stringList = new List<string>();
            if (ValidateData(data))
            {
                stringList.Add($"{GetType().Name}: {data.result}");
                return stringList;
            }
            stringList.Add(StartegyResultParse.ErrorMesage);
            return stringList;
        }
    }
}