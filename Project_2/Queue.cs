using System;

namespace Project_2
{
    internal class Queue
    {
        internal int front;
        internal int rear;
        internal int size;

        internal int capacity;

        internal int[] array;

        public Queue(int capacity)
        {
            this.capacity = capacity;
            front = this.size = 0;
            rear = capacity - 1;
            array = new int[capacity];
        }
    }

    internal class QueueHelper
    {
        //queue full khi size = capacity

        internal bool IsFull(Queue queue)
        {
            return (queue.size == queue.capacity);
        }

        //queue empty khi size =0
        internal bool IsEmpty(Queue queue)
        {
            return (queue.size == 0);
        }

        //them vao queue
        internal void EnQueue(Queue queue, int item)
        {
            if (IsFull(queue))
                return;
            queue.rear = (queue.rear + 1) % queue.capacity;
            queue.array[queue.rear] = item;
            queue.size = queue.size + 1;
            Console.WriteLine("Gia tri {0} duoc them vao queue", item);
        }

        //xoa phan tu trong queue
        internal void DeQueue(Queue queue)
        {
            if (IsEmpty(queue))
            {
                Console.WriteLine("Queue rong");
                return;
            }

            int item = queue.array[queue.front];
            queue.front = (queue.front + 1) % queue.capacity;
            queue.size = queue.size - 1;
            Console.WriteLine("Gia tri {0} da duoc xoa", item);
        }

        //lay phan tu dau tien cua queue
        internal void GetFrontElement(Queue queue)
        {
            if (IsEmpty(queue))
            {
                Console.WriteLine("Queue rong");
                return;
            }

            Console.WriteLine("Gia tri dau tien cua Queue la: {0}", queue.array[queue.front]);
        }

        internal void GetRearElement(Queue queue)
        {
            if (IsEmpty(queue))
            {
                Console.WriteLine("Queue rong");
                return;
            }
            Console.WriteLine("Gia tri cuoi cua Queue: {0}", queue.array[queue.rear]);
        }

        internal void PrintQueue(Queue queue)
        {
            for (int i = queue.front; i <= queue.rear; i++)
                Console.Write(queue.array[i] + " ");

            Console.WriteLine();
        }

    }
}
