using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Lab_7_task1
{
    public class DistributedSystemNode
    {
        private ConcurrentDictionary<DistributedSystemNode, bool> nodes = new ConcurrentDictionary<DistributedSystemNode, bool>();
        private ConcurrentQueue<string> messages = new ConcurrentQueue<string>();

        public string Name { get; private set; }

        public DistributedSystemNode(string name)
        {
            Name = name;
        }

        public void Connect(DistributedSystemNode node)
        {
            nodes[node] = true;
            node.nodes[this] = true;
        }

        public void Disconnect(DistributedSystemNode node)
        {
            nodes[node] = false;
            node.nodes[this] = false;
        }

        public async Task SendMessageAsync(DistributedSystemNode node, string message)
        {
            if (nodes[node])
            {
                await node.ReceiveMessageAsync(message);
            }
        }

        public async Task ReceiveMessageAsync(string message)
        {
            await Task.Run(() => messages.Enqueue(message));
        }

        public async Task ProcessMessagesAsync()
        {
            while (!messages.IsEmpty)
            {
                if (messages.TryDequeue(out string message))
                {
                    await Task.Run(() => Console.WriteLine($"Node {Name} processed message: {message}"));
                }
            }
        }
    }
}