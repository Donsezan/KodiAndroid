namespace KodiAndroid.Logic
{
    public class VolumUp : Logic.IButtonActions
    {
        public string Action()
        {
            var jsParam =  new DataContract.Params();
            jsParam.volume = "increment";
            

            var jsContract = new DataContract.RootObject
            {
                id = 1,
                jsonrpc = "2.0",
                method = "Application.SetVolume",
                @params = jsParam
            };
            var jsSerialMethod = new JsonSerializingMethod();
            var jsFile = jsSerialMethod.Serelize(jsContract);
            var httpClentMethod = new HttpClientMethod();
            var status =  httpClentMethod.PostReqest(jsFile, "192.168.0.206:8080/jsonrpc?Application.SetVolume");
            return status;
        }

        public string UpdateScreen()
        {
            return "to do";
        }

      
    }
}