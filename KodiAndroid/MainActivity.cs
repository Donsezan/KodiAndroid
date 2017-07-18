using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using KodiAndroid.Logic;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", MainLauncher = true, Icon = "@drawable/kodi_logo")]
    public class MainActivity : Activity
    {
        private const int MyPermissionsRequest = 101;

        private void UpdateText(string state)
        {
            var mainText = FindViewById<TextView>(Resource.Id.mainText);
            RunOnUiThread(() =>
            {
                mainText.Text = state;
            });
        }



        protected override void OnCreate(Bundle bundle)
        {
            var tt = new TaskTracker();
            var kodi = new KodiAndroid();
            var img = GetDrawable(Resource.Drawable.mute_off);
            base.OnCreate(bundle);
            ReqestPremision();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(Resource.Layout.Semple);

            // Get the UI controls from the loaded layout:
            var mainText = FindViewById<TextView>(Resource.Id.mainText);
            var powerButton = FindViewById<Button>(Resource.Id.PowerButton);
            var homeButton = FindViewById<Button>(Resource.Id.HomeButton);
            var backButton = FindViewById<Button>(Resource.Id.BackButton);
            var previousButton = FindViewById<Button>(Resource.Id.previousButton);
            var rewindButton = FindViewById<Button>(Resource.Id.rewindButton);
            var playpauseButton = FindViewById<Button>(Resource.Id.playpauseButton);
            var forwardButton = FindViewById<Button>(Resource.Id.forwardButton);
            var nextButton = FindViewById<Button>(Resource.Id.nextButton);
            var upButton = FindViewById<Button>(Resource.Id.upButton);
            var leftButton = FindViewById<Button>(Resource.Id.leftButton);
            var okButton = FindViewById<Button>(Resource.Id.okButton);
            var rightButton = FindViewById<Button>(Resource.Id.rightButton);
            var downButton = FindViewById<Button>(Resource.Id.downButton);
            var volumUpButton= FindViewById<Button>(Resource.Id.VolumUpButton);
            var volumDownButton = FindViewById<Button>(Resource.Id.VolumDownButton);
            var muteButton = FindViewById<ImageButton>(Resource.Id.muteButton);       
            muteButton.SetImageDrawable(img);

          
            tt.TaskCompleted += (sender, eventArgs) =>
            {
                //if (!tt.AllCompleted)
                //{
                //    UpdateText("Task in progress");
                //}
                //else
                //{
                //    UpdateText("No Task in progress");
                //}
            };
           
            
            


            muteButton.Click += (object sender, EventArgs e) =>
            {
                tt.AddTask(Task.Factory.StartNew(() =>
                {
                    kodi.SetStrategy(new Commands.VolumMute());
                    var status = kodi.SendPostReqest();
                    UpdateText(status);


                    //img = GetDrawable(status.Contains("false") ? Resource.Drawable.mute_off : Resource.Drawable.mute_on);
                    //muteButton.SetImageDrawable(img);                   
                },TaskCreationOptions.LongRunning));
            };


            previousButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
                 {
                     kodi.SetStrategy(new Commands.GoToPrevious());
                     var status = kodi.SendPostReqest();
                     UpdateText(status);
                 }, TaskCreationOptions.LongRunning));


            rewindButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.GoToPrevious.SetSpeedDecrement());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            playpauseButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.GoToPrevious.PlayPause());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            forwardButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.GoToPrevious.SetSpeedIncrement());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            nextButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.GoToPrevious.GoToNext());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            powerButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Power());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            upButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Up());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            leftButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Left());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            okButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Select());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            rightButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Right());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            downButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Down());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            homeButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Home());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            backButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.Back());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));


            volumUpButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.VolumUp());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            volumDownButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.VolumDwon());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));

            volumDownButton.Click += (object sender, EventArgs e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                kodi.SetStrategy(new Commands.VolumDwon());
                var status = kodi.SendPostReqest();
                UpdateText(status);
            }, TaskCreationOptions.LongRunning));
        }


        private void ReqestPremision()
    {

        // Here, thisActivity is the current activity
        if (CheckSelfPermission(Manifest.Permission.Internet) != Android.Content.PM.Permission.Granted)
        {

            // Should we show an explanation?
            if (ShouldShowRequestPermissionRationale(Manifest.Permission.Internet))
            {

                // Show an expanation to the user *asynchronously* -- don't block
                // this thread waiting for the user's response! After the user
                // sees the explanation, try again to request the permission.

            }
            else
            {

                // No explanation needed, we can request the permission.

                RequestPermissions(new String[] {Manifest.Permission.Internet}, MyPermissionsRequest);

                // MY_PERMISSIONS_REQUEST_Camera is an
                // app-defined int constant. The callback method gets the
                // result of the request.
            }
        }
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
        [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
        switch (requestCode)
        {
            case 101:
            {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.Length > 0 && grantResults[0] == Android.Content.PM.Permission.Granted)
                {

                    // permission was granted, yay! Do the
                    // contacts-related task you need to do.

                }
                else
                {

                    // permission denied, boo! Disable the
                    // functionality that depends on this permission.
                }
                return;
            }

            // other 'case' lines to check for other
            // permissions this app might request
        }

    }
    }
}

