using KodiAndroid.DataContract;

namespace KodiAndroid.Logic
{
    public class Commands
    {
        public class VolumUp : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new Params { volume = "increment" };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Application.SetVolume",
                    @params = jsParam
                };
                return jsContract;
            }
        }

        public class VolumMute : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new Params { mute = "toggle" };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Application.SetMute",
                    @params = jsParam
                };
                return jsContract;
            }
        }

        public class VolumDwon : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new Params { volume = "decrement" };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Application.SetVolume",
                    @params = jsParam
                };
                return jsContract;
            }
        }

        public class Power : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "System.Shutdown",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Home : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Home",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Back : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Back",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Up : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Up",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Left : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Left",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Select : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Select",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Right : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Right",
                    @params = null
                };
                return jsContract;
            }
        }

        public class Down : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Input.Down",
                    @params = null
                };
                return jsContract;
            }
        }

        public class GoToPrevious : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new Params {playerid = 1, to = "previous"};
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.GoTo",
                    @params = jsParam
                };
                return jsContract;
            }

            public class SetSpeedDecrement : IStrategy
            {
                public RootObject CreateJson()
                {
                    var jsParam = new Params {playerid = 1, speed = "decrement"};
                    var jsContract = new RootObject
                    {
                        id = 1,
                        jsonrpc = "2.0",
                        method = "Player.SetSpeed",
                        @params = jsParam
                    };
                    return jsContract;
                }
            }

            public class PlayPause : IStrategy
            {
                public RootObject CreateJson()
                {
                    var jsParam = new Params {playerid = 1};
                    var jsContract = new RootObject
                    {
                        id = 1,
                        jsonrpc = "2.0",
                        method = "Player.PlayPause",
                        @params = jsParam
                    };
                    return jsContract;
                }
            }

            public class SetSpeedIncrement : IStrategy
            {
                public RootObject CreateJson()
                {
                    var jsParam = new Params {playerid = 1, speed = "increment"};
                    var jsContract = new RootObject
                    {
                        id = 1,
                        jsonrpc = "2.0",
                        method = "Player.SetSpeed",
                        @params = jsParam
                    };
                    return jsContract;
                }
            }


            public class GoToNext : IStrategy
            {
                public RootObject CreateJson()
                {
                    var jsParam = new Params {playerid = 1, to = "next"};
                    var jsContract = new RootObject
                    {
                        id = 1,
                        jsonrpc = "2.0",
                        method = "Player.GoTo",
                        @params = jsParam
                    };
                    return jsContract;
                }
            }
        }
    }
}