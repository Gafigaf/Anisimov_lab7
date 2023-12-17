using System.Threading;

namespace Lab_7_task2
{
    public class Resource
    {
        public string Name { get; private set; }
        public SemaphoreSlim Semaphore { get; private set; }

        public Resource(string name, int initialCount)
        {
            Name = name;
            Semaphore = new SemaphoreSlim(initialCount);
        }
    }
}