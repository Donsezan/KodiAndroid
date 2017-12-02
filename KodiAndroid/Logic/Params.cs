using KodiAndroid.Logic.Service;

namespace KodiAndroid.Logic
{
    public static class Params
    {
        private static string _serverAdress;

        public static string GetServerAdress()
        {
            if (_serverAdress != null) return _serverAdress;
            
            var mySetingsWorker = new SettingsWorker();
            mySetingsWorker.Retrieveset("IpKodiSServer");
            return _serverAdress;
        }

        public static void SetServerAdress(string value)
        {
            _serverAdress = value;
        }
    }


}