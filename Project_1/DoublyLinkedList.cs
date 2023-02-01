using System;

namespace Final_Project.Project_1
{
    public class DoublyLinkedList
    {
        public Node Head;
        public Node Tail;

        public bool isEmpty()
        {
            return (this.Head == null) && (this.Tail == null);
        }
        public void initList()
        {
            this.Head = null; this.Tail = null;
        }
        public void addFirst(IT new_nv)
        {
            Node new_Node = new Node(new_nv);
            if (isEmpty())
                this.Head = this.Tail = new_Node;
            else
            {
                new_Node.next = this.Head;//Con trỏ tiêp theo của new_node là head của list
                new_Node.prev = null;//Con trỏ trước là null
                this.Head = new_Node;
            }
        }
        public void addLast(IT new_nv)
        {
            Node new_Node = new Node(new_nv);
            if (isEmpty())
            {
                this.Head = this.Tail = new_Node;
            }

            else
            {
                Tail.next = new_Node;
                new_Node.prev = Tail;
                Tail = new_Node;
            }
        }
        public void PrintList()
        {
            Node last = this.Head;
            while (last != null)
            {
                Console.WriteLine(last.nv.ToString());
                last = last.next;
            }
        }
        public void addAfter(IT nv, int id)
        {
            if (isEmpty())
            {
                Console.WriteLine("List is empty can't not add element");
            }
            else
            {
                Node p = this.Head;
                while (p.nv.ID != id)
                {
                    p = p.next;
                }
                if (p != null)
                {
                    Node new_Node = new Node(nv);
                    if (p == Tail) // Thêm sau node cuối cùng
                        addLast(new_Node.nv);
                    else
                    {
                        new_Node.next = p.next;
                        p.next.prev = new_Node; // Báo lỗi khi thêm sau pTail
                        p.next = new_Node;
                        new_Node.prev = p;
                    }
                }
            }

        }
        public void removeFirst()
        {
            if (isEmpty())
                Console.WriteLine("List is empty can't not delete element");
            else
            {
                Node p = this.Head;
                this.Head = p.next;
                if (p.next == null) // Chỉ có 1 phần tử
                {
                    this.Tail = null;
                    this.Head = null;
                }
                else
                {
                    p.next.prev = null;
                    p.next = null;
                }
                p = null;
            }
        }
        public void removeLast()
        {
            if (isEmpty())
                Console.WriteLine("List is empty can't not delete element");
            else
            {
                Node p = this.Tail;     // Node cuối sẽ xóa
                if (p.prev == null) // Chỉ có 1 phần tử
                {
                    this.Tail = null;
                    this.Head = null;
                }
                else
                {
                    this.Tail = p.prev;
                    p.prev = null;       // prev của Node sẽ thành null
                    this.Tail.next = null;  // Next của Node mới sẽ  thành null (đang là phần tử cuôi sau khi xóa node cuối)
                }
                p = null;
            }
        }
        public void removeAfter(int id)
        {
            if (isEmpty())
                Console.WriteLine("List is empty can't not delete element");
            else
            {
                Node p = this.Head;
                while (p.nv.ID != id)
                    p = p.next;
                if (p != null)
                {
                    if (p == this.Tail.prev) // Xóa node cuối cùng
                        removeLast();
                    else
                    {
                        Node pDel = p.next;
                        p.next = pDel.next;
                        pDel.next = null;
                        p.next.prev = p;
                        pDel.prev = null;
                        pDel = null;
                    }
                }
            }


            //public int GetCount() { return count; }
            //public void Show()
            //{
            //    IT current = this.Head;
            //    for (int i = 0; i < count; i++)
            //    {
            //        Console.Write("{0} {1} {2} | ", current.Ten, current.Diem, current.MSSV);
            //        if (current.Next != null)
            //        {
            //            current = current.Next;
            //        }
            //        else
            //            break;
            //    }
            //    Console.WriteLine();
            //}
        }
        public void search_ID(int id)
        {
            Node p = this.Head;
            while ((p != null) && (p.nv.ID != id))
                p = p.next;
            Console.WriteLine("Result Search ID: " + p.nv.ToString());
        }
        public void filter_Node(double threshold)
        {
            Node p = Head;
            Console.WriteLine("\nResult Search Field: \n");
            while ((p != null))
            {
                if (p.nv.Luong >= threshold)
                    Console.WriteLine(p.nv.ToString());
                p = p.next;
            }
        }
        Node elementMax(Node head)
        {
            int m = Int32.MinValue;
            Node p = head;
            Node kq = null;
            while (p != null)
            {
                if (p.nv.Luong > m)
                {
                    m = p.nv.Luong;
                    kq = p;
                }
                p = p.next;
            }
            return kq;
        }
        public void SelectionSort()
        {
            Node p = Head;
            while (p != null)
            {
                Node r = elementMax(p);
                if (r != p)
                { // swap
                    IT tmp = p.nv;
                    p.nv = r.nv;
                    r.nv = tmp;
                }
                p = p.next;

            }
        }
        Node partition(Node left, Node right)
        {
            Node pivot = right;
            Node i = left.prev;
            for (Node ptr = left; ptr != right; ptr = ptr.next) // for (int left = 0; left!=right; left++)
                if (ptr.nv.Luong<= pivot.nv.Luong)
                { // swap
                    i = (i == null ? left : i.next);
                    IT tmp = i.nv;
                    i.nv = ptr.nv;
                    ptr.nv = tmp;
                }
            i = (i == null ? left : i.next);
            IT temp = i.nv;
            i.nv = pivot.nv;
            pivot.nv = temp;
            return i;
        }
        public void QuickSort(Node left, Node right)
        {
            if (right != null && left != right && left != right.next)
            {
                Node p = partition(left, right);
                QuickSort(left, p.prev);
                QuickSort(p.next, right);
            }

        }
        public void merge(DoublyLinkedList second)
        {
            this.Tail.next = second.Head;
        }
        public void RemoveNodebyID(int id)
        {
            if (isEmpty())
                Console.WriteLine("List is empty can't not delete element");
            else
            {
                Node p = Head;
                while (p != null)
                {
                    if (p.nv.ID == id)
                    {
                        if (p == Head)
                        {
                            removeFirst();
                            p = Head;
                            continue;
                        }
                        else if (p == Tail)
                        {
                            removeLast();
                            break;
                        }
                        else
                        {
                            p = p.prev;
                            removeAfter(p.nv.ID);
                            continue;
                        }
                    }
                    p = p.next;
                }
            }

        }
        public void Reverse()
        {
            Node temp = null;
            Node current = Head;
            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }
            if (temp != null)
                Head = temp.prev;

        }
    }
}
