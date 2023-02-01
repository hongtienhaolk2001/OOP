using System;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(1000);
            QueueHelper helper = new QueueHelper();

            //String result = "";

            DisplayHeader();
            char option = Console.ReadLine()[0];
            int item;

            while (option != 'Q')
            {
                switch (option)
                {
                    case 'E':
                        Console.Write("Nhap gia tri muon them vao Queue: ");
                        item = Convert.ToInt32(Console.ReadLine());
                        helper.EnQueue(queue, item);
                        break;

                    case 'F':
                        try
                        {
                            helper.GetFrontElement(queue);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 'R':
                        try
                        {
                            helper.GetRearElement(queue);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 'D':
                        try
                        {
                            helper.DeQueue(queue);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 'P':
                        helper.PrintQueue(queue);
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                DisplayHeader();
                option = Console.ReadLine()[0];
            }
        }


        static void DisplayHeader()
        {
            Console.WriteLine("Cac su lua chon: ");
            Console.WriteLine("E - Them phan tu");
            Console.WriteLine("F - Lay phan tu dau tien");
            Console.WriteLine("R - Lay phan tu cuoi cung");
            Console.WriteLine("D - Xoa phan tu");
            Console.WriteLine("P - Xem cac phan tu trong Queue");
            Console.WriteLine("Q - Thoat");
            Console.Write("===>");
        }
    }
}
