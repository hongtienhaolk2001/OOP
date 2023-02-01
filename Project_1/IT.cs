using System;

namespace Final_Project.Project_1
{
    public class IT
    {
        int id;
        string ten;
        string congviec;
        int luong;


        public IT()
        {

        }

        public int ID { get { return id; } set { id = value; } }
        public string Ten { get { return ten; } set { ten = value; } }
        public string CongViec { get { return congviec; } set { congviec = value; } }
        public int Luong { get { return luong; } set { luong = value; } }

        public IT(int ID, string Ten, string CongViec, int Luong)
        {
            this.ID = ID;
            this.Ten = Ten;
            this.congviec = CongViec;
            this.luong = Luong;
        }

        

        public override string ToString()
        {
            return "ID: " + ID + ", Ten: " + Ten + ", CongViec: " + CongViec + ", Luong: " + Luong;
        }
        public string NameOfNode()
        {
            return Ten;
        }
    }
}
