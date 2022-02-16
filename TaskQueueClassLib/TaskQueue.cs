using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskQueueClassLib
{
    public delegate void TaskDelegate(object obj);
    class TaskQueue : IDisposable
    {
        private uint countOfThread;
        private List<TaskPoolThread> tasks;
        private Queue<TaskDelegate> taskDelegates;
        public TaskQueue(uint countOfThread)
        {
            this.countOfThread = countOfThread;
            this.tasks = new List<TaskPoolThread>();
            this.taskDelegates = new Queue<TaskDelegate>();
        }

        public void StartPool()
        {

        }

        private void AddNewTask()
        {

        }

        private void    




        void EnqueueTask(TaskDelegate task)
        {


            taskDelegates.Enqueue(task);


            if (IsHaveFreeThread())
            {
                    
            }
            if (countOfThread > tasks.Count)
            {
                var tempTask = new TaskPoolThread(task);
                tasks.Add(tempTask);
                new Thread(tempTask.StartThread).Start();
            }
            else
            {
               
            }
        }

        public void Dispose()
        {
            this.DestroyTaskQueue();
        }


        public void DestroyTaskQueue()
        {
            while (!IsFreePull());
        }


        private bool IsFreePull()
        {
            foreach(var elem in tasks)
            {
                if (elem.IsFree)
                {
                    return false;
                }
            }
            return true;
        }


        private bool IsHaveFreeThread()
        {
            foreach(var elem in tasks)
            {
                if (!elem.IsFree)
                {
                    return true;
                }
            }
            return false;
        }
    }


    class TaskPoolThread
    {
        public EventWaitHandle eventWaitHandle { get; private set; } = new AutoResetEvent(false);
        public EventWaitHandle eventSetTask { get; private set; } = new AutoResetEvent(false);

        public delegate bool TaskHandler();
        public event TaskHandler Notify;hjkghjk;ghjkghjkghjkgghjk

        public TaskDelegate Function { get; set; }

        public object Parametrs { private get; set; }

        public bool IsFree { get; private set; } = true;

        public TaskPoolThread(TaskDelegate function)
        {
            this.Function = function;
        }

        public void StartThread()
        {
            while (true)
            {
                eventSetTask.WaitOne();
                eventWaitHandle.WaitOne();
                IsFree = false;
                Function.Invoke(Parametrs);
                IsFree = true;
            }

        }

    }
}
