using System;

namespace Lab_7_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Resource cpu = new Resource("CPU", 1);
            Resource ram = new Resource("RAM", 2);
            Resource disk = new Resource("Disk", 1);

            ThreadRunner runner1 = new ThreadRunner("Thread1");
            runner1.AddRequest(new ResourceRequest(cpu, 1));
            runner1.AddRequest(new ResourceRequest(ram, 2));

            ThreadRunner runner2 = new ThreadRunner("Thread2");
            runner2.AddRequest(new ResourceRequest(cpu, 2));
            runner2.AddRequest(new ResourceRequest(disk, 1));

            Console.ReadLine();
        }
    }
}