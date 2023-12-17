using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Lab_7_task4
{
    public class Node
    {
        private static int globalTime = 0;
        private int localTime = 0;
        private ConcurrentDictionary<string, Event> events = new ConcurrentDictionary<string, Event>();

        public string Id { get; private set; }

        public Node(string id)
        {
            Id = id;
        }

        public void RegisterEvent(string name)
        {
            localTime = Math.Max(localTime, globalTime) + 1;
            globalTime = localTime;

            events[name] = new Event(name, localTime);
        }

        public IEnumerable<Event> GetEvents()
        {
            return events.Values;
        }
    }
}