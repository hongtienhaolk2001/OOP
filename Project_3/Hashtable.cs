using System;
namespace Project_3
{

    public class HashTable<T>
    {
        private readonly Node<T>[] _buckets;

        public HashTable(int size)
        {
            _buckets = new Node<T>[size];
        }

        protected void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));
        }

        public T Get(string key)
        {
            ValidateKey(key);
            // gạch dưới _ vì ta ko cần previous node
            var (_, node) = GetNodeByKey(key);//tra về cặp previouse-current node theo key

            if (node == null) throw//nếu node == null thì quăng lỗi
                     new ArgumentException($"Từ '{key}' không tìm thấy!");
            return node.Value;
        }

        public void Add(string key, T item)
        {
            ValidateKey(key);

            var valueNode = new Node<T> { Key = key, Value = item, Next = null };
            int position = GetBucketByKey(key);
            Node<T> listNode = _buckets[position];

            if (null == listNode)// neu chua co node thi tao node moi
            {
                _buckets[position] = valueNode;
            }
            else
            {//neu co roi thì chạy hết cái linklist để tìm node cuối cùng rồi thêm vào
                while (null != listNode.Next) //While vần còn node tiếp theo thì listnode = listnode tiep theo
                {
                    listNode = listNode.Next;
                }
                listNode.Next = valueNode;
            }
        }

        public bool Remove(string key)
        {
            ValidateKey(key);//kt key có rỗng ko
            int position = GetBucketByKey(key);//lấy vị trí bucket của key

            var (previous, current) = GetNodeByKey(key);// Ở đây ta sử dụng cả previous

            if (null == current) return false;
            if (null == previous)// nếu previous node là null nghĩa current node là node đầu tiên trong bucket
            {
                _buckets[position] = null;// nếu là đầu tiên thì ta chỉ việc đổi bucket thành null
                return true;
            }

            previous.Next = current.Next;//Nếu ko rỗng thì ta xóa nó đi và dồn các node phía sau về
            return true;
        }

        public bool ContainsKey(string key)//kt có chứa key ko
        {
            ValidateKey(key);

            var (_, node) = GetNodeByKey(key);
            return null != node;
        }

        public int GetBucketByKey(string key)
        {
            return key[0] % _buckets.Length;

            //return Math.abs(key.GetHashCode() % _buckets.Length);
        }

        protected (Node<T> previous, Node<T> current) GetNodeByKey(string key)
        {
            int position = GetBucketByKey(key);// lấy vị trí của key
            Node<T> listNode = _buckets[position];//listnode = bucket cua key hien tai
            Node<T> previous = null;//phan tu trc đó đặt là null vì ta có thể sẽ remove nó

            while (null != listNode)//traverse linkedList
            {
                if (listNode.Key == key) return (previous, listNode);
                //Nếu tìm đc node có cùng key ta nhập vào
                //thì trả về cặp giá trị của previous node và current node
                previous = listNode;//Nếu ko thì ta tiếp tục traverse
                listNode = listNode.Next;
            }

            return (null, null);//neu ko tim ra gi se tra ve cap null

        }
    }
}
