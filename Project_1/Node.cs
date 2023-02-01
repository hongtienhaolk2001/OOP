
namespace Final_Project.Project_1
{
    public class Node
    {
        public IT nv;
        public Node prev;
        public Node next;

        // next and prev is by default initialized as null  
        public Node(IT nv)
        {
            this.nv = nv;
            this.prev = null;
            this.next = null;
        }
    }
}
