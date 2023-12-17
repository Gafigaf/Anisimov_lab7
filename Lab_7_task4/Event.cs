namespace Lab_7_task4
{
    public class Event
    {
        public string Name { get; private set; }
        public int Timestamp { get; private set; }

        public Event(string name, int timestamp)
        {
            Name = name;
            Timestamp = timestamp;
        }
    }
}