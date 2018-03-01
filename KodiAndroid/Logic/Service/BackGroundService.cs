using System;
using Android.Graphics;
using Android.Widget;
using KodiAndroid.DataContract;

namespace KodiAndroid.Logic.Service
{
    public class BackgroundData
    {
        public string Lables { get; set; }
        public Bitmap PrewView { get; set; }
    }

    public class BackGroundService 
    {
        private readonly KodiAndroid _kodi;
        private readonly BackgroundData _backgroundData;
        private readonly DownloaderImg _downloaderImg = new DownloaderImg();

        public BackGroundService(KodiAndroid kodi)
        {
            _kodi = kodi;
            _backgroundData = new BackgroundData();
        }
        
       
        public BackgroundData GetCurrentPlayingData()
        {
            var jsonService = new JsonService();
            var getPlayinInfo = new Commands.GetPlayinInfo(jsonService);
            _kodi.SetStrategy(getPlayinInfo);
            var status = _kodi.SendPostReqest();

            var response = jsonService.DeSerelize<JsonRpcReceivingApi.ResultObject>(status);
            var result = response.result;
            _backgroundData.Lables = result.item.label;
            var mainAmg = result.item.thumbnail.Substring(8).TrimEnd('/');
            _backgroundData.PrewView = _downloaderImg.GetImageBitmapFromUrl(mainAmg);
            return _backgroundData;  
        }
    }
}