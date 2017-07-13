namespace KodiAndroid.Logic
{
    public class VolumUp : Logic.IButtonActions
    {
        public string Action()
        {
            var jsContract = new DataContract.RootObject
            {
                id = 0,
                jsonrpc = "sd",
                method = "true",
                @params =
                {
                    playerid = 30,
                    properties = null
                }
            };
            var jsSerialMethod = new JsonSerializingMethod();
            var jsFile = jsSerialMethod.Serelize(jsContract);
            var httpClentMethod = new HttpClientMethod();
            var status =  httpClentMethod.PostReqest(jsFile, "ya.ru");
            return status;
        }

        public string UpdateScreen()
        {
            return "to do";
        }

      
    }
}