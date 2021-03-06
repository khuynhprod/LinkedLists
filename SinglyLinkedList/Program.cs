using System.Text;
using Newtonsoft.Json;

MySinglyLinkedList linkedList = new MySinglyLinkedList();
linkedList.Add(1);
linkedList.Add(2);
linkedList.Add(3);
linkedList.Add(4);


//Console.WriteLine(JsonConvert.SerializeObject(linkedList, Formatting.Indented));

linkedList.Print();
linkedList.Reverse();
linkedList.Print();
Console.ReadLine();




public class MySinglyLinkedList
{
	public Node Head { get; set; }
	public Node Tail { get; set; }
	public int Length { get; set; }

	public void Add(int Value)
	{
		Node newNode = new Node(Value);

		if (Head == null)
		{
			Head = newNode;
			Tail = newNode;
		}
		else
		{
			newNode.Next = Head;
			Head = newNode;
		}
		this.Length++;
	}

	public void Insert(int Index, int Value)
    {

    }

	public void RemoveValue(int Value)
	{
		Node curNode = this.Head;
		Node prevNode = null;

		while (curNode != null && curNode.Value != Value)
		{
			prevNode = curNode;
			curNode = curNode.Next;
		}

		if (curNode != null)
		{
			if (prevNode != null)
			{
				prevNode.Next = curNode.Next;
				if (prevNode.Next == null)
					this.Tail = prevNode;
			}
			else
			{
				this.Head = curNode.Next;
			}

			this.Length--;
		}
		else
		{
			Console.WriteLine("Nothing to remove.");
		}
	}

	public void RemoveAt(int Index)
	{
		if (Index < 0)
		{
			Console.WriteLine("Index out of bound.");
			return;
		}

		int idx = 0;
		Node curNode = this.Head;
		Node prevNode = null;

		while (curNode != null && idx != Index)
		{
			prevNode = curNode;
			curNode = curNode.Next;
			idx++;
		}

		if (curNode != null)
		{
			if (prevNode != null)
			{
				prevNode.Next = curNode.Next;
				if (prevNode.Next == null)
					this.Tail = prevNode;
			}
			else
			{
				this.Head = curNode.Next;
			}

			this.Length--;
		}
		else
		{
			Console.WriteLine("Index out of bound.");
		}
	}

	public void Reverse()
    {
		if (this.Head == null)
        {
			Console.WriteLine("List is empty.");
        }
		else
        {
            Node prev = null, next = null;
            Node curr = this.Head;
			this.Tail = curr;
            
			while (curr != null)
            {
				next = curr.Next; //store next node in nextNode first
				curr.Next = prev; //point current node pointer to previous node
				prev = curr; // set prev to current node
				curr = next; // set current node to next node
            }

			this.Head = prev;
        }
	}

	public void ReverseRecursively()
    {
		//if (head == null || head.Next == null)
		//{
		//	return head;
		//}
		//Node p = reverseListRecursively(head.Next);
		//head.Next.Next = head;
		//head.Next = null;
		//return p;
	}

	public void Print()
	{
		if (this.Head != null)
		{
			StringBuilder sb = new StringBuilder();
			Node curNode = Head;

			while (curNode != null)
			{
				sb.Append(curNode.Value + " ");
				curNode = curNode.Next;
			}

			Console.WriteLine(sb.ToString());
			Console.WriteLine($"Head: {this.Head.Value}");
			Console.WriteLine($"Tail: {this.Tail.Value}");
			Console.WriteLine($"Length: {this.Length}");
		}
		else
		{
			Console.WriteLine("List is empty.");
		}
	}
}

public class Node
{
	public int Value { get; set; }
	public Node Next { get; set; }

	public Node(int Value)
	{
		this.Value = Value;
	}
}