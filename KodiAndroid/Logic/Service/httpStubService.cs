using System;

namespace KodiAndroid.Logic.Service
{
    public class HttpStubService
    {
        #region Command Requests 
        private const string BackCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Back\",\"id\":1}";
        private const string DownCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Down\",\"id\":1}";
        private const string GetPlayinInfoCommand =
                "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetItem\",\"id\":1,\"params\":{\"properties\":[\"title\",\"season\",\"episode\",\"plot\",\"runtime\",\"showtitle\",\"thumbnail\"],\"playerid\":1}}";
        private const string GoToNextCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GoTo\",\"id\":1,\"params\":{\"playerid\":1,\"to\":\"next\"}}";
        private const string GoToPreviousCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GoTo\",\"id\":1,\"params\":{\"playerid\":1,\"to\":\"previous\"}}";
        private const string HomeCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Home\",\"id\":1}";
        private const string LeftCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Left\",\"id\":1}";
        private const string PleyPauseCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.PlayPause\",\"id\":1,\"params\":{\"playerid\":1}}";
        private const string PowerCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"System.Shutdown\",\"id\":1}";
        private const string RightCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Right\",\"id\":1}";
        private const string SelectCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Select\",\"id\":1}";
        private const string SetSpeedDecrementCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.SetSpeed\",\"id\":1,\"params\":{\"playerid\":1,\"speed\":\"decrement\"}}";
        private const string SetSpeedIncrementCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.SetSpeed\",\"id\":1,\"params\":{\"playerid\":1,\"speed\":\"increment\"}}";
        private const string UpCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Input.Up\",\"id\":1}";
        private const string VolumDownCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Application.SetVolume\",\"id\":1,\"params\":{\"volume\":\"decrement\"}}";
        private const string VolumMuteCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Application.SetMute\",\"id\":1,\"params\":{\"mute\":\"toggle\"}}";
        private const string VolumUpCommand = "{\"jsonrpc\":\"2.0\",\"method\":\"Application.SetVolume\",\"id\":1,\"params\":{\"volume\":\"increment\"}}";

        private const string ResponseOk = "{\"id\":1,\"jsonrpc\":\"2.0\",\"result\":\"OK\"}";
        #endregion

        public string PostReqest(string file, string url)
        {
            var validateUrl = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                          && uriResult.Scheme == Uri.UriSchemeHttp;
            if (!validateUrl)
            {
                throw new ArgumentException("incorrect url");
            }

            switch (file)
            {
                case BackCommand:
                    return ResponseOk;
                case SelectCommand:
                    return ResponseOk;
                case DownCommand:
                    return ResponseOk;
                case GetPlayinInfoCommand:
                    return "{\"id\":1,\"jsonrpc\":\"2.0\",\"result\":{\"item\":{\"episode\":-1,\"label\":\"ELUVEITIE - Omnos (OFFICIAL MUSIC VIDEO)\",\"plot\":\"[UPPERCASE][B]Nuclear Blast Records[/B][/UPPERCASE][CR][CR]Official music video for ELUVEITIE \\\"Omnos.\\\"\\nGET THE ALBUM: http://store.nuclearblastusa.com/Artist/Eluveitie/92077\\nSUBSCRIBE to Eluveitie: http://bit.ly/subs-eluvtie-yt \\nSUBSCRIBE to Nuclear Blast YouTube: http://bit.ly/subs-nb-yt\\n\\n\\\"Omnos\\\" is taken from the album, Evocation I: The Arcane Dominion.\\n\\nCheck out EluTV, Eluveitie's very own free online documentary series at\\nwww.eluveitie.ch, and Eluveitie's official YouTube channel at\\nwww.youtube.com/eluveitieofficial\\n\\nPURCHASE THE ALBUM HERE:\\n  \\n▶ITUNES: http://georiot.co/1MrA\\n\\n▶AMAZON: http://georiot.co/1mb5\\n\\nCONNECT WITH US: \\n\\n▶OFFICIAL SITE: http://eluveitie.ch/band/\\n\\n▶FACEBOOK: https://www.facebook.com/eluveitie\\n\\n▶TWITTER: https://twitter.com/eluveitie\\n\\n▶SUBSCRIBE to Eluveitie: http://bit.ly/subs-eluvtie-yt \\n\\n▶SUBSCRIBE to Nuclear Blast YouTube: http://bit.ly/subs-nb-yt\",\"runtime\":236,\"season\":-1,\"showtitle\":\"\",\"thumbnail\":\"image://https%3a%2f%2fi.ytimg.com%2fvi%2fmsRy4vcSX4k%2fhqdefault.jpg/\",\"title\":\"ELUVEITIE - Omnos (OFFICIAL MUSIC VIDEO)\",\"type\":\"unknown\"}}}";
                case GoToNextCommand:
                    return ResponseOk;
                case GoToPreviousCommand:
                    return ResponseOk;
                case HomeCommand:
                    return ResponseOk;
                case LeftCommand:
                    return ResponseOk;
                case PleyPauseCommand:
                    return "{\"id\":1,\"jsonrpc\":\"2.0\",\"result\":{\"speed\":0}}";
                case PowerCommand:
                    return ResponseOk;
                case RightCommand:
                    return ResponseOk;
                case SetSpeedDecrementCommand:
                    return "{\"id\":1,\"jsonrpc\":\"2.0\",\"result\":{\"speed\":1}}";
                case SetSpeedIncrementCommand:
                    return "{\"id\":1,\"jsonrpc\":\"2.0\",\"result\":{\"speed\":2}}";
                case UpCommand:
                    return ResponseOk;
                case VolumDownCommand:
                    return "{ \"id\":1,\"jsonrpc\":\"2.0\",\"result\":59}";
                case VolumMuteCommand:
                    return "{\"id\":1,\"jsonrpc\":\"2.0\",\"result\":false}";
                case VolumUpCommand:
                    return "{ \"id\":1,\"jsonrpc\":\"2.0\",\"result\":60}";
                default:
                    return "NetworkError";
            }
        }
    }
}