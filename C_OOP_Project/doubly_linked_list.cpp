#include <iostream>
#include <fstream>
#include <climits>
#include <stdio.h>

using namespace std;
// Struct
typedef struct IT
{
    int ID;         // ID Role
    char Field[50]; // Lĩnh Vực
    char Role[50];  // Vị Trí
    int Salary;     // Mức Lương
} IT;
struct Node
{
    IT *data;        // Kiểu dữ liệu của node
    Node *pNext;     // Trỏ đến Node kế tiếp
    Node *pPrevious; // Trỏ đến Node phía sau
};
struct DoublyLinkedList
{
    Node *pHead; // luôn trỏ đến phần tử đầu tiên
    Node *pTail; // luôn trỏ đến phần tử sau cùng
};
// Function
Node *createNode(IT *country);
void initList(DoublyLinkedList &list);
IT *enterIT();
void input_first_List(DoublyLinkedList &list);
void input_last_List(DoublyLinkedList &list);
void input_after_Node(DoublyLinkedList &list, int id);
void printList(DoublyLinkedList list);
void printNode(IT *country);
void read_txt(DoublyLinkedList &list, string path);
bool isEmptyList(DoublyLinkedList list);
void addtFirst(DoublyLinkedList &list, IT *country);
void addLast(DoublyLinkedList &list, IT *country);
void addAfter(DoublyLinkedList &list, int id, IT *added_country);
void removeFirst(DoublyLinkedList &list);
void removeLast(DoublyLinkedList &list);
void removeAfter(DoublyLinkedList &list, int id);
void search_ID(DoublyLinkedList list, int id);
void filter_Node(DoublyLinkedList list, double threshold);
Node *elementMax(Node *head);
void SelectionSort(DoublyLinkedList &list);
Node *partition(Node *left, Node *right);
void QuickSort(Node *left, Node *right);
void merge(DoublyLinkedList &first, Node *second);
void RemoveNode(DoublyLinkedList &list, int id);
void Reverse(DoublyLinkedList &list);
void program(DoublyLinkedList &list, DoublyLinkedList &list_2);

int main()
{
    DoublyLinkedList VietNam, American;
    string vietnam_path = "D:\\Code\\C++\\Project\\VietNam.txt";
    string american_path = "D:\\Code\\C++\\Project\\American.txt";
    initList(VietNam);
    initList(American);
    read_txt(VietNam, vietnam_path);
    read_txt(American, american_path);
    // merge(VietNam.pHead, &American.pHead);
    // printList(VietNam);
    // printList(American);
    program(VietNam, American);
    return 0;
}

// Initialize
Node *createNode(IT *country)
{
    Node *pNode = new Node;
    if (pNode != NULL)
    {
        pNode->data = country;
        pNode->pNext = NULL;
        pNode->pPrevious = NULL;
    }
    else
        cout << "Don't have enough memory space to allocate";
    return pNode;
}
void initList(DoublyLinkedList &list)
{
    list.pHead = NULL;
    list.pTail = NULL;
}
// I/O
IT *enterIT()
{
    IT *country = new IT;
    cout << "Enter Role ID: ";
    cin >> country->ID;
    cin.ignore();
    cout << "Enter Field: ";
    cin.getline(country->Field, 50);
    cout << "Enter Role: ";
    cin.getline(country->Role, 50);
    cout << "Enter Average Salary: ";
    cin >> country->Salary;
    return country;
}
void input_last_List(DoublyLinkedList &list)
{
    IT *tmp = enterIT();
    addLast(list, tmp);
}
void input_first_List(DoublyLinkedList &list)
{
    IT *tmp = enterIT();
    addtFirst(list, tmp);
}
void input_after_Node(DoublyLinkedList &list, int id)
{
    IT *tmp = enterIT();
    addAfter(list, id, tmp);
}
void printList(DoublyLinkedList list)
{
    Node *p = list.pHead;
    cout << "\n----------Doubly Linked List--------------\n";
    while (p != NULL)
    {
        printNode(p->data);
        p = p->pNext;
    }
}
void printNode(IT *country)
{
    cout << country->ID << "\t" << country->Field << "\t\t\t" << country->Role << "\t\t" << country->Salary << "\n";
}
void read_txt(DoublyLinkedList &list, string path)
{
    ifstream fileInput(path);
    if (fileInput.fail())
        cout << "\nFailed to open this file!\n";
    else
    {
        cout << "\nOpen this file success!\n";
        int row = 1;
        while (!fileInput.eof())
        {
            IT *country = new IT;
            char temp[50];
            fileInput.getline(temp, 50);
            for (int i = 0; i < 50; i++)
            {
                country->Field[i] = temp[i];
            }
            fileInput.getline(temp, 50);
            country->ID = atoi(temp);
            fileInput.getline(temp, 50);
            for (int i = 0; i < 50; i++)
            {
                country->Role[i] = temp[i];
            }
            fileInput.getline(temp, 50);
            country->Salary = atoi(temp);
            addLast(list, country);
            // row += 1;
            // if (row == 4)
            // {
            // line = 1;
            // }
        }
    }
    fileInput.close();
}
// Check
bool isEmptyList(DoublyLinkedList list)
{ // Nếu danh sách rỗng, pHead sẽ không trỏ đến phần tử nào cả
    if (list.pHead == NULL)
        return true;
    return false;
}
// Insert Node
void addtFirst(DoublyLinkedList &list, IT *country)
{
    Node *pNode = createNode(country);
    if (isEmptyList(list))
        list.pHead = list.pTail = pNode;
    else
    {
        pNode->pNext = list.pHead;
        list.pHead->pPrevious = pNode;
        list.pHead = pNode;
    }
}
void addLast(DoublyLinkedList &list, IT *country)
{
    Node *pNode = createNode(country);
    if (isEmptyList(list))
        list.pHead = list.pTail = pNode;
    else
    {
        pNode->pPrevious = list.pTail;
        list.pTail->pNext = pNode;
        list.pTail = pNode;
    }
}
void addAfter(DoublyLinkedList &list, int id, IT *added_country)
{
    if (isEmptyList(list))
        cout << "List is empty can't not add element";
    else
    {
        Node *p = list.pHead;
        while (p->data->ID != id)
            p = p->pNext;
        if (p != NULL)
        {
            if (p == list.pTail) // Thêm sau node cuối cùng
                addLast(list, added_country);
            else
            {
                Node *pNode = createNode(added_country);
                pNode->pNext = p->pNext;
                p->pNext->pPrevious = pNode; // Báo lỗi khi thêm sau pTail
                p->pNext = pNode;
                pNode->pPrevious = p;
            }
        }
    }
}
// Delete Node
void removeFirst(DoublyLinkedList &list)
{
    if (isEmptyList(list))
        cout << "List is empty can't not delete element";
    else
    {
        Node *p = list.pHead;
        list.pHead = p->pNext;
        if (p->pNext == NULL) // Chỉ có 1 phần tử
        {
            list.pTail = NULL;
            list.pHead = NULL;
        }
        else
        {
            p->pNext->pPrevious = NULL;
            p->pNext = NULL;
        }
        delete (p);
    }
}
void removeLast(DoublyLinkedList &list)
{
    if (isEmptyList(list))
        cout << "List is empty can't not delete element";
    else
    {
        Node *p = list.pTail;     // Node cuối sẽ xóa
        if (p->pPrevious == NULL) // Chỉ có 1 phần tử
        {
            list.pTail = NULL;
            list.pHead = NULL;
        }
        else
        {
            list.pTail = p->pPrevious; // Gán pTail cũ sang pTail mới
            p->pPrevious = NULL;       // pPrevious của Node sẽ thành NULL
            list.pTail->pNext = NULL;  // pNext của Node mới sẽ  thành NULL (đang là phần tử cuôi sau khi xóa node cuối)
        }
        delete (p);
    }
}
void removeAfter(DoublyLinkedList &list, int id)
{
    if (isEmptyList(list))
        cout << "List is empty can't not delete element";
    else
    {
        Node *p = list.pHead;
        while (p->data->ID != id)
            p = p->pNext;
        if (p != NULL)
        {
            if (p == list.pTail->pPrevious) // Xóa node cuối cùng
                removeLast(list);
            else
            {
                Node *pDel = p->pNext;
                p->pNext = pDel->pNext;
                pDel->pNext = NULL;
                p->pNext->pPrevious = p;
                pDel->pPrevious = NULL;
                delete (pDel);
            }
        }
    }
}
// Search Node
void search_ID(DoublyLinkedList list, int id) // Tìm kiếm theo ID
{
    Node *p = list.pHead;
    cout << "Result Search ID: \n";
    while ((p != NULL))
    {
        if ((p->data->ID == id))           
            printNode(p->data);
        p = p->pNext;      
    }        
}
void filter_Node(DoublyLinkedList list, double threshold)
{
    Node *p = list.pHead;
    cout << "\nResult Search Field: \n";
    while ((p != NULL))
    {
        if (p->data->Salary >= threshold)
            printNode(p->data);
        p = p->pNext;
    }
}
// Sort
Node *elementMax(Node *head)
{
    int m = INT_MIN;
    Node *p = head;
    Node *kq = NULL;
    while (p != NULL)
    {
        if (p->data->Salary > m)
        {
            m = p->data->Salary;
            kq = p;
        }
        p = p->pNext;
    }
    return kq;
}
void SelectionSort(DoublyLinkedList &list)
{
    Node *p = list.pHead;
    while (p != NULL)
    {
        Node *r = elementMax(p);
        if (r != p)
        { // swap
            IT *tmp = p->data;
            p->data = r->data;
            r->data = tmp;
        }
        p = p->pNext;
    }
}
Node *partition(Node *left, Node *right)
{

    Node *pivot = right;
    Node *i = left->pPrevious;
    for (Node *ptr = left; ptr != right; ptr = ptr->pNext) // for (int left = 0; left!=right; left++)
        if (ptr->data->Salary <= pivot->data->Salary)
        { // swap
            i = (i == NULL ? left : i->pNext);
            IT *temp = i->data;
            i->data = ptr->data;
            ptr->data = temp;
        }
    i = (i == NULL ? left : i->pNext);
    IT *temp = i->data;
    i->data = pivot->data;
    pivot->data = temp;
    return i;     
}
void QuickSort(Node *left, Node *right)
{
    if (right != NULL && left != right && left != right->pNext)
    {
        Node *p = partition(left, right);
        QuickSort(left, p->pPrevious);
        QuickSort(p->pNext, right);
    }
}
// Operation
void merge(DoublyLinkedList &first, Node *second)
{
    Node *firstRef = first.pTail;
    firstRef->pNext = second;
}
void RemoveNode(DoublyLinkedList &list, int id)
{
    if (isEmptyList(list))
        cout << "List is empty can't not delete element";
    else
    {
        Node *p = list.pHead;
        while (p != NULL)
        {
            if (p->data->ID == id)
            {
                if (p == list.pHead)
                {
                    removeFirst(list);
                    p = list.pHead;
                    continue;
                }
                else if (p == list.pTail)
                {
                    removeLast(list);
                    break;
                }
                else
                {
                    p = p->pPrevious;
                    removeAfter(list, p->data->ID);
                    continue;
                }
            }
            p = p->pNext;
        }
    }
}
void Reverse(DoublyLinkedList &list)
{
    Node *temp = NULL;
    Node *current = list.pHead;
    while (current != NULL)
    {
        temp = current->pPrevious;
        current->pPrevious = current->pNext;
        current->pNext = temp;
        current = current->pPrevious;
    }
    if (temp != NULL)
        list.pHead = temp->pPrevious;
}
// Driver
void program(DoublyLinkedList &list, DoublyLinkedList &list_2)
{
    int Selection = -1;
    do
    {
        cout << "\nCommand List:";
        cout << "\n1: Check Null List ";
        cout << "\n2: Print List ";
        cout << "\n3: Enter Element (First List) ";
        cout << "\n4: Enter Element (Last List) ";
        cout << "\n5: Enter Element (After ID) ";
        cout << "\n6: Remove First Element in List";
        cout << "\n7: Remove Last Element in List";
        cout << "\n8: Remove Element After Node by ID ";
        cout << "\n9: Search by ID ";
        cout << "\n10: Filter Salary Bigger than";
        cout << "\n11: Selection Sort Salary (Desc)";
        cout << "\n12: Quick Sort List Salary (Asc)";
        cout << "\n13: Merge List";
        cout << "\n14: Remove Node by ID";
        cout << "\n15: Reverse List";
        cout << "\n16: Exit";
        cout << "\nEnter Selection: ";
        cin >> Selection;
        switch (Selection)
        {
        case 1:
        {
            if (isEmptyList(list))
                cout << "\nNull List!";
            else
                cout << "\nNot Null List!";
            break;
        }
        case 2:
        {
            printList(list);
            break;
        }
        case 3:
        {
            input_first_List(list);
            break;
        }
        case 4:
        {
            input_last_List(list);
            break;
        }
        case 5:
        {
            int id = -1;
            cout << "After ID: ";
            cin >> id;
            input_after_Node(list, id);
            break;
        }
        case 6:
        {
            removeFirst(list);
            break;
        }
        case 7:
        {
            removeLast(list);
            break;
        }
        case 8:
        {
            int id = -1;
            cout << "After ID: ";
            cin >> id;
            removeAfter(list, id);
            break;
        }
        case 9:
        {
            int id = -1;
            cout << "Search ID: ";
            cin >> id;
            search_ID(list, id);
            break;
        }
        case 10:
        {
            double salary = -1;
            cout << "Larger Salary: ";
            cin >> salary;
            filter_Node(list, salary);
            break;
        }
        case 11:
        {
            SelectionSort(list);
            printList(list);
            break;
        }
        case 12:
        {
            QuickSort(list.pHead, list.pTail);
            printList(list);
            break;
        }
        case 13:
        {
            merge(list_2, list.pHead);
            printList(list_2);
            break;
        }
        case 14:
        {
            int id = -1;
            cout << "\nEnter ID: ";
            cin >> id;
            RemoveNode(list, id);
            printList(list);
            break;
        }
        case 15:
        {
            Reverse(list);
            printList(list);
            break;
        }
        }
    } while (Selection != 16);
}