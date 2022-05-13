using System.Text;

MyDoublyLinkedList linkedList = new MyDoublyLinkedList();
linkedList.Add(1);
linkedList.Add(2);
linkedList.Add(3);
linkedList.Add(4);

linkedList.RemoveValue(1);
linkedList.RemoveValue(2);
linkedList.RemoveValue(3);
linkedList.RemoveValue(4);

linkedList.Print();
Console.ReadLine();




public class MyDoublyLinkedList
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
			Tail = Head;
		}
		else
		{
			this.Head.Prev = newNode;
			newNode.Next = this.Head;
			this.Head = newNode;
		}
		this.Length++;
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
				else
					prevNode.Next.Prev = prevNode;
			}
			else
			{
				this.Head = curNode.Next;

				// not an empty list
				if (this.Head != null)
					this.Head.Prev = null;
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
				else
					prevNode.Next.Prev = prevNode;
			}
			else
			{
				this.Head = curNode.Next;

				// not an empty list
				if (this.Head != null)
					this.Head.Prev = null;
			}

			this.Length--;
		}
		else
		{
			Console.WriteLine("Index out of bound.");
		}
	}

	public void Print()
	{
		if (this.Head != null)
		{
			StringBuilder sb = new StringBuilder();
			Node curNode = Head;

			while (curNode != null)
			{
				sb.Append(curNode.Value + " -> ");
				curNode = curNode.Next;
			}

			sb.Append(" | ");

			curNode = Tail;

			while (curNode != null)
			{
				sb.Append(curNode.Value + " -> ");
				curNode = curNode.Prev;
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
	public Node Prev { get; set; }

	public Node(int Value)
	{
		this.Value = Value;
	}
}