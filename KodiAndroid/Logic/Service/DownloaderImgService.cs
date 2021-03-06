﻿using System;
using System.Net;
using Android.Graphics;

namespace KodiAndroid.Logic.Service
{
    public class DownloaderImgService
    {
        public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            var webClient = new WebClient();
            try
            {
                url = Uri.UnescapeDataString(url);
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            catch (WebException)
            {

            }
            finally
            {
                webClient.Dispose();
            }
            return imageBitmap;
        }
    }
}