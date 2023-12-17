namespace Lab_7_task2
{
    public class ResourceRequest
    {
        public Resource Resource { get; private set; }
        public int Priority { get; private set; }

        public ResourceRequest(Resource resource, int priority)
        {
            Resource = resource;
            Priority = priority;
        }
    }
}