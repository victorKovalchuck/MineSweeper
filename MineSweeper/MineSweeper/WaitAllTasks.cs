using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class WaitAllTasks : TaskScheduler
    {

        protected override void QueueTask(Task task)
        {
            this.TryExecuteTask(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool wasPreviouslyQueued)
        {
            return this.TryExecuteTask(task);
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            yield break;
        }
    }
}
