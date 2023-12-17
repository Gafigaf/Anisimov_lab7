using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_7_task2
{
    public class ThreadRunner
    {
        private List<ResourceRequest> requests = new List<ResourceRequest>();
        private Thread thread;

        public ThreadRunner(string name)
        {
            thread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        requests.Sort((a, b) => b.Priority.CompareTo(a.Priority));

                        foreach (var request in requests)
                        {
                            if (request.Resource.Semaphore.Wait(0))
                            {
                                Console.WriteLine($"{name} acquired {request.Resource.Name}");
                                Thread.Sleep(1000);
                                request.Resource.Semaphore.Release();
                                Console.WriteLine($"{name} released {request.Resource.Name}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in {name}: {ex.Message}");
                    }

                    Thread.Sleep(1000);
                }
            });

            thread.Start();
        }

        public void AddRequest(ResourceRequest request)
        {
            requests.Add(request);
        }
    }
}