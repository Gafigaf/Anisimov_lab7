using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Lab_7_task4
{
    public class EventSystem
    {
        private ConcurrentDictionary<string, Node> nodes = new ConcurrentDictionary<string, Node>();

        public void AddNode(string id)
        {
            nodes[id] = new Node(id);
        }

        public void RemoveNode(string id)
        {
            nodes.TryRemove(id, out _);
        }

        public void RegisterEvent(string nodeId, string eventName)
        {
            if (nodes.ContainsKey(nodeId))
            {
                nodes[nodeId].RegisterEvent(eventName);
            }
        }

        public IEnumerable<Event> GetEvents(string nodeId)
        {
            if (nodes.ContainsKey(nodeId))
            {
                return nodes[nodeId].GetEvents();
            }

            return new List<Event>();
        }
    }
}