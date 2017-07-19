using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace KodiAndroid.Logic
{
    public class TaskTracker
    {
        public event EventHandler TaskCompleted;
        public event EventHandler TaskStarted;
        private ConcurrentBag<Task> _tasks = new ConcurrentBag<Task>();
        public bool AllCompleted => _tasks.Aggregate(true, (b, task) => b && task.IsCompleted);
        public void AddTask(Task task)
        {
            _tasks.Add(task.ContinueWith(t => TaskCompleted?.Invoke(this, EventArgs.Empty)));
            TaskStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}