


using MyLinkedList;

SinglyLinkedList singlyLinkedList = new SinglyLinkedList();
singlyLinkedList.Add(new Node(5));
singlyLinkedList.Add(new Node(4));
singlyLinkedList.Add(new Node(3));
singlyLinkedList.Add(new Node(2));
singlyLinkedList.Add(new Node(1));


//Node head = singlyLinkedList.Head;
//Node prevNode = null;
//Node curNode = head;
//Node nextNode = null;

//while (curNode != null)
//{
//    //store next node in nextNode first
//    nextNode = curNode.Next;

//    // point current node back to previous node
//    curNode.Next = prevNode;

//    // move previous node to current node
//    prevNode = curNode;

//    // move current node to next node
//    curNode = nextNode;

//}

//singlyLinkedList.Head = prevNode;

singlyLinkedList.Head = reverseListRecursively(singlyLinkedList.Head);

singlyLinkedList.Print();
Console.ReadLine();

Node reverseListRecursively(Node head)
{
    if (head == null || head.Next == null)
    {
        return head;
    }
    Node p = reverseListRecursively(head.Next);
    head.Next.Next = head;
    head.Next = null;
    return p;
}