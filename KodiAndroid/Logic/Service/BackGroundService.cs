using Android.Graphics;
using Android.Widget;

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
            _kodi.SetStrategy(new Commands.GetPlayinInfo());
            var status = _kodi.SendPostReqest();
            var jsonService = new JsonService();
            var response = jsonService.DeSerelize(status);
            if (_currentPlayingTitle != response.result.item.label)
            {
                _currentPlayingTitle = response.result.item.label;
                _textView.Text = _currentPlayingTitle;
            }
            
            var mainAmg = response.result.item.thumbnail.Substring(8).TrimEnd('/');
            
            if (_imageBitmap != _downloaderImg.GetImageBitmapFromUrl(mainAmg))
            {
                _imageBitmap = _downloaderImg.GetImageBitmapFromUrl(mainAmg);
                _imgImageView.SetImageBitmap(_imageBitmap);
            }
            
        }
    }
}