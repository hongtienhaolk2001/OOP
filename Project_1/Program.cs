using System;

namespace Final_Project.Project_1
{
    internal class Program
    {
        public static void Main(String[] args)
        {

            DoublyLinkedList list = new DoublyLinkedList();
            list.initList();
            IT nv1 = new IT(1, "Nguyen Van A", "Coder", 10000000);
            IT nv2 = new IT(2, "Nguyen Van B", "Tester", 10000000);
            IT nv3 = new IT(3, "Nguyen Van C", "Leader", 20000000);
            IT nv4 = new IT(4, "Nguyen Van D", "Fresher", 15000000);
            IT nv5 = new IT(5, "Nguyen Van E", "Designer", 30000000);
            IT nv6 = new IT(6, "Nguyen Van F", "Fresher", 45000000);
            IT nv7 = new IT(7, "Nguyen Van G", "Designer", 10000000);
            IT nv8 = new IT(8, "Nguyen Van H", "Tester", 5000000);
            IT nv9 = new IT(9, "Nguyen Van I", "Coder", 9000000);
            IT nv10 = new IT(10, "Nguyen Van J", "Coder", 10000000);
            list.addLast(nv1);                                          //nv1-null
            list.addLast(nv2);                                          //nv1-nv2-null
            list.addFirst(nv7);                                         //nv7-nv1-nv2-null
            list.addFirst(nv5);                                         //nv5-nv7-nv1-nv2-null
            list.addFirst(nv10);                                        //nv10-nv5-nv7-nv1-nv2-null
            list.addLast(nv6);                                          //nv10-nv5-nv7-nv1-nv2-nv6-null
            list.addAfter(nv3, 7);     //nv10-nv5-nv7-nv3-nv1-nv2-nv6-null

            DoublyLinkedList list2 = new DoublyLinkedList();
            list2.initList();
            list2.addLast(nv2);
            list2.addLast(nv2);
            list2.addLast(nv1);

            string b, c;
            int a, d, e;
            bool flag = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Danh Sach");
                list.PrintList();
                Console.WriteLine("\nCommand List");
                Console.WriteLine("1: Check Null List ");
                Console.WriteLine("2: Enter Element (First List) ");
                Console.WriteLine("3: Enter Element (Last List) ");
                Console.WriteLine("4: Enter Element (After ID) ");
                Console.WriteLine("5: Remove First Element in List");
                Console.WriteLine("6: Remove Last Element in List");
                Console.WriteLine("7: Remove Element After Node by ID ");
                Console.WriteLine("8: Search by ID ");
                Console.WriteLine("9: Filter Salary higher than");
                Console.WriteLine("10: Selection Sort Salary (Desc)");
                Console.WriteLine("11: Quick Sort List Salary (Asc)");
                Console.WriteLine("12: Merge List");
                Console.WriteLine("13: Remove All Node by ID");
                Console.WriteLine("14: Reverse List");
                Console.WriteLine("15: Exit");
                Console.WriteLine("Enter Selection: ");
                Console.Write("Nhap Lua chon: ");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        if (list.isEmpty())
                            Console.WriteLine("Null List!");
                        else
                            Console.WriteLine("Not Null List!");
                        break;
                    case 2:
                        Console.Write("Enter ID: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        b = Console.ReadLine();
                        Console.Write("Enter Role: ");
                        c = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        d = Convert.ToInt32(Console.ReadLine());
                        list.addFirst(new IT(a,b,c,d));
                        break;
                    case 3:
                        Console.Write("Enter ID: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        b = Console.ReadLine();
                        Console.Write("Enter Role: ");
                        c = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        d = Convert.ToInt32(Console.ReadLine());
                        list.addLast(new IT(a, b, c, d));                        
                        break;
                    case 4:
                        Console.Write("Enter ID: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        b = Console.ReadLine();
                        Console.Write("Enter Role: ");
                        c = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        d = Convert.ToInt32(Console.ReadLine());
                        Console.Write("you want add after ID: ");
                        e = Convert.ToInt32(Console.ReadLine());
                        list.addAfter(new IT(a, b, c, d), e);
                        break;
                    case 5:
                        list.removeFirst();
                        break;
                    case 6:
                        list.removeLast();
                        break;
                    case 7:                        
                        Console.Write("you want remove after ID: ");
                        e = Convert.ToInt32(Console.ReadLine());
                        list.removeAfter(e);
                        break;
                    case 8:
                        Console.Write("search ID: ");
                        e = Convert.ToInt32(Console.ReadLine());
                        list.search_ID(e);
                        break;
                    case 9:
                        Console.Write("Salary higher than: ");
                        e = Convert.ToInt32(Console.ReadLine());
                        list.filter_Node(e);
                        break;
                    case 10:
                        list.SelectionSort();
                        break;
                    case 11:
                        list.QuickSort(list.Head, list.Tail);
                        break;
                    case 12:
                        list.merge(list2);
                        break;
                    case 13:
                        Console.Write("Enter ID you want remove ALL: ");
                        e = Convert.ToInt32(Console.ReadLine());
                        list.RemoveNodebyID(e);                        
                        break;
                    case 14:
                        list.Reverse();
                        break;
                    case 15:
                        flag = false;
                        break;                        
                }
            } while (flag);
        }
    }
}
