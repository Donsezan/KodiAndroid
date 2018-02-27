using Android.Graphics;
using Android.Widget;
using KodiAndroid.DataContract;

namespace KodiAndroid.Logic.Service
{
    public class BackGroundService 
    {
        private readonly KodiAndroid _kodi;
        private readonly ImageView _imgImageView;
        private readonly TextView _textView;
        private string _currentPlayingTitle;
        private Bitmap _imageBitmap;
        private readonly DownloaderImg _downloaderImg = new DownloaderImg();

        public BackGroundService(KodiAndroid kodi, TextView textView, ImageView imgImageView)
        {
            _kodi = kodi;
            _textView = textView;
            _imgImageView = imgImageView;
        }
        
       
        public void UpadeteData()
        {
            var jsonService = new JsonService();

            var getPlayinInfo = new Commands.GetPlayinInfo(jsonService);
            _kodi.SetStrategy(getPlayinInfo);
            var status = _kodi.SendPostReqest();

            var response = jsonService.DeSerelize<JsonRpcReceivingApi.ResultObject>(status);
            var result = response.result;

            if (_currentPlayingTitle != result.item.label)
            {
                _currentPlayingTitle = result.item.label;
                _textView.Text = _currentPlayingTitle;
            }
            
            var mainAmg = result.item.thumbnail.Substring(8).TrimEnd('/');
            
            if (_imageBitmap != _downloaderImg.GetImageBitmapFromUrl(mainAmg))
            {
                _imageBitmap = _downloaderImg.GetImageBitmapFromUrl(mainAmg);
                _imgImageView.SetImageBitmap(_imageBitmap);
            }
            
        }
    }
}