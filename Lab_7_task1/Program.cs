using System;
using System.Threading.Tasks;

namespace Lab_7_task1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DistributedSystemNode node1 = new DistributedSystemNode("Node1");
            DistributedSystemNode node2 = new DistributedSystemNode("Node2");

            node1.Connect(node2);

            await node1.SendMessageAsync(node2, "Hello from Node1!");

            await node2.ProcessMessagesAsync();

            node1.Disconnect(node2);
        }
    }
}