using System;
using System.Threading.Tasks;

namespace KodiAndroid.Logic.Service
{
    public class TaskTracker
    {
        public event EventHandler TaskCompleted;

        public async void AddTask(Action action)
        {
            await Task.Factory.StartNew(action);
            TaskCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}