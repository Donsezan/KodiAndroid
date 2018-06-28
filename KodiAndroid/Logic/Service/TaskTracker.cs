using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KodiAndroid.Logic.Service
{
    public class TaskTracker
    {
        public event EventHandler TaskCompleted;
        private static readonly ConcurrentQueue<Action> ActionQueue = new ConcurrentQueue<Action>();
        private static bool _runingAction;

        //public async void AddTask(Action action)
        //{
        //    await Task.Factory.StartNew(action);
        //    TaskCompleted?.Invoke(this, EventArgs.Empty);
        //}

        public void AddTask(Action action)
        {
            ActionQueue.Enqueue(action);
            if (!_runingAction)
            {
                StartToInvokeFunction();
                _runingAction = true;
            }
        }

        private void StartToInvokeFunction()
        {
            var cts = new CancellationToken();
            Task.Factory.StartNew(async () =>
            {
                while (ActionQueue.Any())
                {
                    ActionQueue.TryDequeue(out Action action);
                    await Task.Factory.StartNew(action, cts);
                    await Task.Delay(100, cts);
                }
                _runingAction = false;
            }, cts);
            TaskCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}