using System.Collections.Generic;
using KodiAndroid.DataContract;

namespace KodiAndroid.Logic
{
    public static class StartegyResultParse
    {
        public  static string ErrorMesage = "";
    }

    public interface IBaseStrategy
    {
        RootObject CreateJson();

        List<string> EncodeResponse(string data);
    }
}