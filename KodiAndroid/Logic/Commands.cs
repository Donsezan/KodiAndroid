using System;
using System.Collections.Generic;
using KodiAndroid.DataContract;

namespace KodiAndroid.Logic
{
    public class Commands
    {
       private const string ErrorMesage = "Network Error";

        public class VolumUp : IStrategy
        {
           
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params { volume = "increment" };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Application.SetVolume",
                    @params = jsParam
                };
                return jsContract;
            }

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {

                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Volume: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }
        }

        public class VolumMute : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params { mute = "toggle" };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Application.SetMute",
                    @params = jsParam
                };
                return jsContract;
            }

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Mute: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }
        }

        public class VolumDwon : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params { volume = "decrement" };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Application.SetVolume",
                    @params = jsParam
                };
                return jsContract;
            }

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Volume: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Power: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Home: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Back: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Up: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Left: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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
            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Select: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
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
            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Right: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return rootObject != null;
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
            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Down: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }

        }

        public class GoToPrevious : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params {playerid = 1, to = "previous"};
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.GoTo",
                    @params = jsParam
                };
                return jsContract;
            }

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Previous: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }
        }
    
        public class SetSpeedDecrement : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params {playerid = 1, speed = "decrement"};
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.SetSpeed",
                    @params = jsParam
                };
                return jsContract;
            }
            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Decrement speed to: {rootObject.result.speed}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }
        }

        public class PlayPause : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params {playerid = 1};
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.PlayPause",
                    @params = jsParam
                };
                return jsContract;
            }
            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add(rootObject.result.speed == 0 ? "Pause" : "Play");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return rootObject.result == null & rootObject.jsonrpc == null;
            }
        }

        public class SetSpeedIncrement : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params {playerid = 1, speed = "increment"};
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.SetSpeed",
                    @params = jsParam
                };
                return jsContract;
            }
            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Increment speed to: {rootObject.result.speed}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }
        }

        public class GoToNext : IStrategy
        {
            public RootObject CreateJson()
            {
                var jsParam = new DataContract.Params {playerid = 1, to = "next"};
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.GoTo",
                    @params = jsParam
                };
                return jsContract;
            }

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();
                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add($"Next: {rootObject.result}");
                return stringList;
            }
            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(rootObject.id == 0 & rootObject.result == null & rootObject.jsonrpc == null & rootObject.method == null);
            }
        }

        public class GetPlayinInfo : IStrategy
        {
            public RootObject CreateJson()
            {
                //var properties = new DataContract.Params().properties;
                //properties.Add("title");
                //properties.Add("season");
                //properties.Add("episode");
                //properties.Add("plot");
                //properties.Add("runtime");
                //properties.Add("showtitle");
                //properties.Add("thumbnail");

                var jsProperties = new List<string>
                {
                    "title",
                    "season",
                    "episode",
                    "plot",
                    "runtime",
                    "showtitle",
                    "thumbnail"
                };

                var jsParam = new DataContract.Params { playerid = 1, properties = jsProperties };
                var jsContract = new RootObject
                {
                    id = 1,
                    jsonrpc = "2.0",
                    method = "Player.GetItem",
                    @params = jsParam
                };
                return jsContract;
            }

            public List<string> EncodeResponse(JsonRpcReceivingApi.RootObject rootObject)
            {
                var stringList = new List<string>();

                if (ValidateData(rootObject))
                {
                    stringList.Add(ErrorMesage);
                    return stringList;
                }
                stringList.Add(rootObject.result.item.label);
                stringList.Add(rootObject.result.item.thumbnail);
                return stringList;
            }

            public bool ValidateData(JsonRpcReceivingApi.RootObject rootObject)
            {
                return !(
                    rootObject.id == 0 
                    & rootObject.jsonrpc == null 
                    & rootObject.result.item.thumbnail == null
                    & rootObject.result.item.label == null
                    );
            }
        }

    }
}