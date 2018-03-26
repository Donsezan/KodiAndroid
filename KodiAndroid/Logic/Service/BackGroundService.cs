using System;
using Android.Graphics;
using KodiAndroid.DataContracts;

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
        private readonly DownloaderImgService _downloaderImgService = new DownloaderImgService();

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
            if (response != null) { _backgroundData.Lables = response.result.item.label; }

            if (response != null && response.result.item.thumbnail != string.Empty)
            {
                var mainAmg = response.result.item.thumbnail.Substring(8).TrimEnd('/');
                _backgroundData.PrewView = _downloaderImgService.GetImageBitmapFromUrl(mainAmg);
            }
            else
            {
                _backgroundData.PrewView = null;
            }

            return _backgroundData;  
        }
    }
}