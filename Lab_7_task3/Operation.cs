using System;

namespace Lab_7_task3
{
    public class Operation
    {
        public string ThreadId { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Resource { get; private set; }

        public Operation(string threadId, string resource)
        {
            ThreadId = threadId;
            Resource = resource;
            Timestamp = DateTime.Now;
        }
    }
}