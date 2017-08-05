using System.Collections.Generic;
using System.ComponentModel;

namespace KodiAndroid.DataContract
{
    public class Params
    {
        [DefaultValue(null)]
        public List<string> properties { get; set; }

        [DefaultValue(0)]
        public int playerid { get; set; }

        [DefaultValue(null)]
        public string volume { get; set; }

        [DefaultValue(null)]
        public string to { get; set; }

        [DefaultValue(null)]
        public string speed { get; set; }

        [DefaultValue(null)]
        public string mute { get; set; }
    }

    public class RootObject
    {
        public string jsonrpc { get; set; }

        public string method { get; set; }

        public int id { get; set; }

        [DefaultValue(null)]
        public Params @params { get; set; }

        [DefaultValue(null)]
        public Result result { get; set; }
    }

    public class Time
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
    }

    public class Totaltime
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
    }

    public class Result
    {
        public int playlistid { get; set; }
        public int position { get; set; }
        public int speed { get; set; }
        public Time time { get; set; }
        public Totaltime totaltime { get; set; }
    }
}