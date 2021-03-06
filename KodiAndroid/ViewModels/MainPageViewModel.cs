﻿using System;
using Android.App;
using Android.Widget;
using System.Threading;
using Android.Graphics;
using KodiAndroid.Logic;
using System.Threading.Tasks;
using KodiAndroid.Logic.Service;
using KodiAndroid.Logic.Commands;
using System.Collections.Generic;
using KodiAndroid.Entire;

namespace KodiAndroid.ViewModels
{
    public class MainPageViewModel
    {
        private readonly Logic.KodiAndroid _kodi = new Logic.KodiAndroid();
        private readonly JsonService _jsonService = new JsonService();
        private readonly Params _params = new Params();
        private readonly Activity _activity;
        private readonly object _titleLockObject = new object();
        private readonly object _logoLockObject = new object();
        private readonly object _globalLock = new object();
        private const int MaxTextLenght = 45;

        public MainPageViewModel(Activity activity)
        {
            _activity = activity;
        }

        private void Action(IBaseStrategy strategy)
        {
            lock (_globalLock)
            {
                _kodi.SetStrategy(strategy);
                _kodi.Vibrate(_activity);
                var response = _kodi.SendPostReqest();
                var list = strategy.EncodeResponse(response);
                UpdateText(list);
            }
        }

        private void UpdateText(List<string> state)
        {
            var mainText = _activity.FindViewById<TextView>(Resource.Id.mainText);
            _activity.RunOnUiThread(() =>
            {
                mainText.Text = state[0].Length > MaxTextLenght ? @"¯\_(ツ)_/¯" : state[0];
            });
        }

        public void MainViewActivity()
        {
            string toolBarLabel = $"\t \t \t \t \t \t Welcome {_params.AppName} v {_params.AppVersion}";
            var img = _activity.GetDrawable(Resource.Drawable.mute_off);
            var toolBarPrewView = BitmapFactory.DecodeResource(_activity.Resources, Resource.Drawable.blank_title);


            #region Get the UI controls from the loaded layout:
            var powerButton = _activity.FindViewById<Button>(Resource.Id.PowerButton);
            var homeButton = _activity.FindViewById<Button>(Resource.Id.HomeButton);
            var backButton = _activity.FindViewById<Button>(Resource.Id.BackButton);
            var previousButton = _activity.FindViewById<Button>(Resource.Id.previousButton);
            var rewindButton = _activity.FindViewById<Button>(Resource.Id.rewindButton);
            var playpauseButton = _activity.FindViewById<Button>(Resource.Id.playpauseButton);
            var forwardButton = _activity.FindViewById<Button>(Resource.Id.forwardButton);
            var nextButton = _activity.FindViewById<Button>(Resource.Id.nextButton);
            var upButton = _activity.FindViewById<Button>(Resource.Id.upButton);
            var leftButton = _activity.FindViewById<Button>(Resource.Id.leftButton);
            var okButton = _activity.FindViewById<Button>(Resource.Id.okButton);
            var rightButton = _activity.FindViewById<Button>(Resource.Id.rightButton);
            var downButton = _activity.FindViewById<Button>(Resource.Id.downButton);
            var volumUpButton = _activity.FindViewById<Button>(Resource.Id.VolumUpButton);
            var volumDownButton = _activity.FindViewById<Button>(Resource.Id.VolumDownButton);
            var muteButton = _activity.FindViewById<ImageButton>(Resource.Id.muteButton);
            muteButton.SetImageDrawable(img);

            // Replace ToolBar
            var toolbar = _activity.FindViewById<Toolbar>(Resource.Id.toolbar);
            var tolbarImg = _activity.FindViewById<ImageView>(Resource.Id.toolbarImg);
            var tolbarTxt = _activity.FindViewById<TextView>(Resource.Id.toolbarText);

            #endregion

            _activity.SetActionBar(toolbar);
            _activity.ActionBar.Title = String.Empty;
            tolbarImg.SetImageBitmap(toolBarPrewView);
            tolbarTxt.Text = toolBarLabel;
            tolbarTxt.Selected = true;
            
            var tt = new TaskTracker();

            tt.TaskCompleted += async (sender, e) =>
            {
               await UpdateTitle(tolbarImg, toolBarLabel, toolBarPrewView, tolbarTxt);
            };
           
            #region Buttons command

            muteButton.Click += (sender, e) => tt.AddTask(() =>  Action(new VolumMute(_jsonService)));

            previousButton.Click += (sender, e) => tt.AddTask(() => Action(new GoToPrevious(_jsonService)));

            rewindButton.Click += (sender, e) => tt.AddTask(() => Action(new SetSpeedDecrement(_jsonService)));

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

        private async Task UpdateTitle(ImageView tolbarImg, string toolBarLabel, Bitmap toolBarPrewView,TextView tolbarTxt)
        {
            var background = new BackGroundService(_kodi);
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var displayData =
                await Task.Factory.StartNew(background.GetCurrentPlayingData, token);

            _activity.RunOnUiThread(() =>
            {
                if (toolBarLabel != displayData.Lables)
                {
                    lock (_titleLockObject)
                    {
                        toolBarLabel = displayData.Lables;
                        tolbarTxt.Text = toolBarLabel != string.Empty ? toolBarLabel : "\t \t \t \t \t \t No Title";
                    }
                }

                if (toolBarPrewView != displayData.PrewView)
                {
                    lock (_logoLockObject)
                    {
                        toolBarPrewView = displayData.PrewView;
                        tolbarImg.SetImageBitmap(displayData.PrewView ??
                                                 BitmapFactory.DecodeResource(_activity.Resources,
                                                     Resource.Drawable.blank_title));
                    }
                }
            });
        }
    }
}