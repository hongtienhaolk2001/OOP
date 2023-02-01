namespace Project_3
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
