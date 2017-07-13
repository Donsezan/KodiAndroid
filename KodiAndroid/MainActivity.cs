using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Runtime;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        readonly int _myPermissionsRequest = 101;

        protected override void OnCreate(Bundle bundle)
        {
            var kodi = new KodiAndroid();
            base.OnCreate(bundle);
            ReqestPremision();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(Resource.Layout.Semple);
            // Get the UI controls from the loaded layout:
            TextView phoneNumberText = FindViewById<TextView>(Resource.Id.editText1);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);
       

            // Disable the "Call" button
            callButton.Enabled = false;

            // Add code to translate number
            string translatedNumber = string.Empty;

            translateButton.Click += async (object sender, EventArgs e) =>
            {
                var sizeTask = kodi.PostRequests();
            
                //phoneNumberText.Text = kodi.Status;

                phoneNumberText.Text = await sizeTask;

            };
            callButton.Click += (object sender, EventArgs e) =>
            {
                //// On "Call" button click, try to dial phone number.
                //var callDialog = new AlertDialog.Builder(this);
                //callDialog.SetMessage("Call " + translatedNumber + "?");
                //callDialog.SetNeutralButton("Call", delegate
                //{
                //    // Create intent to dial phone
                //    var callIntent = new Intent(Intent.ActionCall);
                //    callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                //    StartActivity(callIntent);
                //});
                //callDialog.SetNegativeButton("Cancel", delegate { });

                //// Show the alert dialog to the user and wait for response.
                //callDialog.Show();
            };
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

                    RequestPermissions(new String[] {Manifest.Permission.Internet}, _myPermissionsRequest);

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

