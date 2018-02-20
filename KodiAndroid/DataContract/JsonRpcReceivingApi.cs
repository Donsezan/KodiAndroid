using System.ComponentModel;

namespace KodiAndroid.DataContract
{
    public class JsonRpcReceivingApi 
    {
        //[KnownType(typeof(ResultString))]
        //[KnownType(typeof(ResultBool))]
        //[KnownType(typeof(ResultObject))]
        public class RootObject
        {
            public int id { get; set; }
            public string jsonrpc { get; set; }
            public string method { get; set; }
            //public object result { get; set; }
        }

        public class ResultString : RootObject
        {
            public string result { get; set; }
        }

        public class ResultBool : RootObject
        {
            public bool result { get; set; }
        }

        public class ResultObject : RootObject
        {
            public Result result { get; set; }
        }
        //public class RootObject
        //{
        //    public int id { get; set; }
        //    public string jsonrpc { get; set; }
        //    [DefaultValue(null)]
        //    public object result { get; set; }
        //    //public int result { get; set; }
        //    //public bool result { get; set; }
        //    public string method { get; set; }
        //}

        public class Limits
        {
            public int end { get; set; }
            public int start { get; set; }
            public int total { get; set; }
        }

        public class Result
        {
            [DefaultValue(null)]
            public int playlistid { get; set; }
            [DefaultValue(null)]
            public int position { get; set; }
            [DefaultValue(null)]
            public int speed { get; set; }
            [DefaultValue(null)]
            public Time time { get; set; }
            [DefaultValue(null)]
            public Totaltime totaltime { get; set; }
            [DefaultValue(null)]
            public Item item { get; set; }
            [DefaultValue(null)]
            public Limits limits { get; set; }
        }
        public class Totaltime
        {
            public int hours { get; set; }
            public int milliseconds { get; set; }
            public int minutes { get; set; }
            public int seconds { get; set; }
        }
        public class Time
        {
            public int hours { get; set; }
            public int milliseconds { get; set; }
            public int minutes { get; set; }
            public int seconds { get; set; }
        }
        public class Item
        {
            public int episode { get; set; }
            public string label { get; set; }
            public string plot { get; set; }
            public int runtime { get; set; }
            public int season { get; set; }
            public string showtitle { get; set; }
            public string thumbnail { get; set; }
            public string title { get; set; }
            public string type { get; set; }
        }
    }
}