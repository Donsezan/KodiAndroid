using System.Collections.Generic;
using KodiAndroid.DataContracts;

namespace KodiAndroid.Logic
{
    public static class StartegyResultParse
    {
        public  static string ErrorMesage = "Response Error";
    }

    public interface IBaseStrategy
    {
        RootObject CreateJson();

        List<string> EncodeResponse(string data);
    }
}