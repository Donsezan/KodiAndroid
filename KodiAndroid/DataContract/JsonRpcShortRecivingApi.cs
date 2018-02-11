namespace KodiAndroid.DataContract
{
    public class JsonRpcShortRecivingApi
    {
        public class RootObject
        {
            public int id { get; set; }
            public string jsonrpc { get; set; }
            public bool result { get; set; }
        }
    }
}