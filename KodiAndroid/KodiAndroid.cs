using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Provider;
using KodiAndroid.Logic;


namespace KodiAndroid
{
    public class KodiAndroid
    {
        public string Status;

        public async Task PostRequests()
        {
            var myVolume = new VolumUp();
            myVolume.Action();
            myVolume.UpdateScreen();

        }



    }
}