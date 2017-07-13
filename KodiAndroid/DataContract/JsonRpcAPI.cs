﻿using System.Collections.Generic;
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

    }

    public class RootObject
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }

        public Params @params { get; set; }

        public int id { get; set; }
    }
}