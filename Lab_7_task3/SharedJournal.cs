using System;
using System.Collections.Concurrent;

namespace Lab_7_task3
{
    public class SharedJournal
    {
        private ConcurrentDictionary<string, Operation> operations = new ConcurrentDictionary<string, Operation>();

        public void LogOperation(string threadId, string resource)
        {
            var operation = new Operation(threadId, resource);

            if (operations.ContainsKey(resource))
            {
                var lastOperation = operations[resource];

                if ((operation.Timestamp - lastOperation.Timestamp).TotalMilliseconds < 100)
                {
                    Console.WriteLine($"Conflict detected: Thread {threadId} and Thread {lastOperation.ThreadId} tried to access {resource} at the same time.");
                    return;
                }
            }

            operations[resource] = operation;
        }
    } 
}
