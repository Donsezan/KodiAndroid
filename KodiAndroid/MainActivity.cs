using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;
using KodiAndroid.Logic;
using KodiAndroid.Logic.Commands;
using KodiAndroid.Logic.Service;

namespace KodiAndroid
{
    [Activity(Label = "KodiAndroid", MainLauncher = true, Icon = "@drawable/kodi_logo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private const int MyPermissionsRequest = 101;
        private readonly Logic.KodiAndroid _kodi = new Logic.KodiAndroid();
        private readonly JsonService _jsonService = new JsonService();

        private void UpdateText(List<string> state)
        {
            var mainText = FindViewById<TextView>(Resource.Id.mainText);
            RunOnUiThread(() =>
            {
                mainText.Text = state[0];
            });
        }

        private void Action(IBaseStrategy strategy)
        {
            _kodi.SetStrategy(strategy);
            _kodi.Vibrate(this);
            var response = _kodi.SendPostReqest();
            var list = strategy.EncodeResponse(response);

            UpdateText(list);
        }

        // add buttons to tollbar
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(OptionsActivity));
            return base.OnOptionsItemSelected(item);
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            var init = new DataService(this);
            init.LoadPreferences();

            var tt = new TaskTracker();       
            var img = GetDrawable(Resource.Drawable.mute_off);
            var toolBarLabele = "\t \t \t \t \t \t Welcome KodiAndroid v 1.2";
            var toolBarPrewView = BitmapFactory.DecodeResource(Resources, Resource.Drawable.blank_title);
            var background = new BackGroundService(_kodi);
            base.OnCreate(bundle);
            ReqestPremision();
            SetContentView(Resource.Layout.Main);

            // Get the UI controls from the loaded layout:
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

            // Replace ToolBar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            var tolbarImg = FindViewById<ImageView>(Resource.Id.toolbarImg);
            var tolbarTxt = FindViewById<TextView>(Resource.Id.toolbarText);
            SetActionBar(toolbar);

            ActionBar.Title = String.Empty;
            tolbarImg.SetImageBitmap(toolBarPrewView);
            tolbarTxt.Text = toolBarLabele;
            tolbarTxt.Selected = true;
            var taskStatus = true;
            
            tt.TaskCompleted += (sender, e) =>
            {
                if (taskStatus)
                {
                    var displayData = Task.Factory.StartNew(background.GetCurrentPlayingData);
                    taskStatus = false;
                    Task.WaitAll(displayData);
                    if (toolBarLabele != displayData.Result.Lables)
                    {
                        try
                        {
                            tolbarTxt.Text = toolBarLabele = displayData.Result.Lables;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                        }
                    }
                    if (toolBarPrewView != displayData.Result.PrewView)
                    {
                        toolBarPrewView = displayData.Result.PrewView;
                        try
                        {
                            tolbarImg.SetImageBitmap(displayData.Result.PrewView);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                    taskStatus = true;
                }
               
            };
   
            #region Buttons command
            muteButton.Click += (sender, e) =>
            {
                tt.AddTask(Task.Factory.StartNew(() =>
                {
                 Action(new VolumMute(_jsonService));                 
                },TaskCreationOptions.LongRunning));
            };

            previousButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new GoToPrevious(_jsonService));
            }, TaskCreationOptions.LongRunning));

            rewindButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new SetSpeedDecrement(_jsonService));
            }, TaskCreationOptions.LongRunning));

            playpauseButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new PlayPause(_jsonService));
            }, TaskCreationOptions.LongRunning));

            forwardButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new SetSpeedIncrement(_jsonService));
            }, TaskCreationOptions.LongRunning));

            nextButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new GoToNext(_jsonService));
            }, TaskCreationOptions.LongRunning));

            powerButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Power(_jsonService));
            }, TaskCreationOptions.LongRunning));

            upButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Up(_jsonService));
            }, TaskCreationOptions.LongRunning));

            leftButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Left(_jsonService));
            }, TaskCreationOptions.LongRunning));

            okButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Select(_jsonService));
            }, TaskCreationOptions.LongRunning));

            rightButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Right(_jsonService));
            }, TaskCreationOptions.LongRunning));

            downButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Down(_jsonService));
            }, TaskCreationOptions.LongRunning));

            homeButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Home(_jsonService));
            }, TaskCreationOptions.LongRunning));

            backButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new Back(_jsonService));
            }, TaskCreationOptions.LongRunning));


            volumUpButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new VolumUp(_jsonService));
            }, TaskCreationOptions.LongRunning));

            volumDownButton.Click += (sender, e) => tt.AddTask(Task.Factory.StartNew(() =>
            {
                Action(new VolumDown(_jsonService));
            }, TaskCreationOptions.LongRunning));
            #endregion
        }

        private void ReqestPremision()
    {

        // Here, thisActivity is the current activity
        if (CheckSelfPermission(Manifest.Permission.Internet) != Permission.Granted)
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

                RequestPermissions(new[] {Manifest.Permission.Internet}, MyPermissionsRequest);

                // MY_PERMISSIONS_REQUEST_Camera is an
                // app-defined int constant. The callback method gets the
                // result of the request.
            }
        }
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
        [GeneratedEnum] Permission[] grantResults)
    {
        switch (requestCode)
        {
            case 101:
            {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
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

