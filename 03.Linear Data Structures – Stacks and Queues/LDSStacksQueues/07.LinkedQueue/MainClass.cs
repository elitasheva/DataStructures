namespace LinkedQueue
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
        }
    }
}
