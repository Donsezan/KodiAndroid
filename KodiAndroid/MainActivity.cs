using System;
using System.Collections.Generic;
using System.Threading;
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

                   
            var img = GetDrawable(Resource.Drawable.mute_off);
            var toolBarLabel = "\t \t \t \t \t \t Welcome KodiAndroid v 1.2";
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
            tolbarTxt.Text = toolBarLabel;
            tolbarTxt.Selected = true;

            var lockObject = new object();
            var taskRunning = false;
            var cts = new CancellationTokenSource();

            var tt = new TaskTracker();
            tt.TaskCompleted += async (sender, e) =>
            {
                lock (lockObject)
                {
                    if (taskRunning)
                    {
                        cts.Cancel(false);
                    }
                    taskRunning = true;
                    cts = new CancellationTokenSource();
                }
                var token = cts.Token;

                var displayData =
                    await Task.Factory.StartNew(background.GetCurrentPlayingData, token);

                if (token.IsCancellationRequested)
                {
                    return;
                }

                taskRunning = false;

                RunOnUiThread(() =>
                {
                    if (toolBarLabel != displayData.Lables)
                    {
                        tolbarTxt.Text = toolBarLabel = displayData.Lables;
                    }

                    if (toolBarPrewView != displayData.PrewView)
                    {
                        toolBarPrewView = displayData.PrewView;
                        tolbarImg.SetImageBitmap(toolBarPrewView != null ? displayData.PrewView : BitmapFactory.DecodeResource(Resources, Resource.Drawable.blank_title));
                    }
                });
            };
   
            #region Buttons command

            muteButton.Click += (sender, e) => { tt.AddTask(() => Action(new VolumMute(_jsonService))); };

            previousButton.Click += (sender, e) => tt.AddTask(() => { Action(new GoToPrevious(_jsonService)); });

            rewindButton.Click += (sender, e) => tt.AddTask(() => { Action(new SetSpeedDecrement(_jsonService)); });

            playpauseButton.Click += (sender, e) => tt.AddTask(() => { Action(new PlayPause(_jsonService)); });

            forwardButton.Click += (sender, e) => tt.AddTask(() => { Action(new SetSpeedIncrement(_jsonService)); });

            nextButton.Click += (sender, e) => tt.AddTask(() => { Action(new GoToNext(_jsonService)); });

            powerButton.Click += (sender, e) => tt.AddTask(() => { Action(new Power(_jsonService)); });

            upButton.Click += (sender, e) => tt.AddTask(() => { Action(new Up(_jsonService)); });

            leftButton.Click += (sender, e) => tt.AddTask(() => { Action(new Left(_jsonService)); });

            okButton.Click += (sender, e) => tt.AddTask(() => { Action(new Select(_jsonService)); });

            rightButton.Click += (sender, e) => tt.AddTask(() => { Action(new Right(_jsonService)); });

            downButton.Click += (sender, e) => tt.AddTask(() => { Action(new Down(_jsonService)); });

            homeButton.Click += (sender, e) => tt.AddTask(() => { Action(new Home(_jsonService)); });

            backButton.Click += (sender, e) => tt.AddTask(() => { Action(new Back(_jsonService)); });

            volumUpButton.Click += (sender, e) => tt.AddTask(() => { Action(new VolumUp(_jsonService)); });

            volumDownButton.Click += (sender, e) => tt.AddTask(() => { Action(new VolumDown(_jsonService)); });

            #endregion
        }

        private void ReqestPremision()
    {
        if (CheckSelfPermission(Manifest.Permission.Internet) != Permission.Granted)
        {
            if (ShouldShowRequestPermissionRationale(Manifest.Permission.Internet))
            {
            }
            else
            {
                RequestPermissions(new[] {Manifest.Permission.Internet}, MyPermissionsRequest);
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
                    if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                    {}
                    else
                    {
                    }
                    return;
                }
            }
        }
    }
}

