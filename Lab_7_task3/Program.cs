using System;

namespace Lab_7_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            SharedJournal journal = new SharedJournal();

            Worker worker1 = new Worker("1", journal);
            Worker worker2 = new Worker("2", journal);

            Console.ReadLine();
        }
    }
}