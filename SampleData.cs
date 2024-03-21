using System.Collections.Concurrent;

namespace background_Task
{
    public class SampleData
    {
        public ConcurrentBag<string> Data { get; set; } = new();

    }
}
