using System;

namespace Lab_7_task4
{
    class Program
    {
        static void Main(string[] args)
        {
            EventSystem system = new EventSystem();

            system.AddNode("Node1");
            system.AddNode("Node2");

            system.RegisterEvent("Node1", "Event1");
            system.RegisterEvent("Node2", "Event2");

            foreach (var e in system.GetEvents("Node1"))
            {
                Console.WriteLine($"Event: {e.Name}, Timestamp: {e.Timestamp}");
            }

            system.RemoveNode("Node1");

            Console.ReadLine();
        }
    }
}