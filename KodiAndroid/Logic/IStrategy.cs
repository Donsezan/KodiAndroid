using KodiAndroid.DataContract;

namespace KodiAndroid.Logic
{
    public interface IStrategy
    {
        RootObject CreateJson();
    }
}