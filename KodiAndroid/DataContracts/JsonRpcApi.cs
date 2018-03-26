using System.Collections.Generic;
using System.ComponentModel;

namespace KodiAndroid.DataContracts
{
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

    public class Limits
    {
        public int end { get; set; }
        public int start { get; set; }
        public int total { get; set; }
    }

    public class Result
    {
        public int playlistid { get; set; }
        public int position { get; set; }
        public int speed { get; set; }

        [DefaultValue(null)]
        public Time time { get; set; }
        [DefaultValue(null)]
        public Totaltime totaltime { get; set; }
        [DefaultValue(null)]
        public List<Item> items { get; set; }
        [DefaultValue(null)]
        public Limits limits { get; set; }
    }
}