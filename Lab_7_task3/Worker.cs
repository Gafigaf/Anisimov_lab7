using System;
using System.Threading;

namespace Lab_7_task3
{
    public class Worker
    {
        private Thread thread;
        private SharedJournal journal;

        public Worker(string id, SharedJournal journal)
        {
            this.journal = journal;

            thread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        journal.LogOperation(id, "Resource");
                        Thread.Sleep(50);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in Thread {id}: {ex.Message}");
                    }
                }
            });

            thread.Start();
        }
    }
}