using System.Text;

MyQueue myQueue = new MyQueue();
myQueue.Enqueue(1);
myQueue.Enqueue(2);
myQueue.Enqueue(3);


myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();

myQueue.Enqueue(4);
myQueue.Enqueue(3);
myQueue.Enqueue(2);

myQueue.Print();


Console.ReadLine();




public class MyQueue
{
	public Node First { get; set; }
	public Node Last { get; set; }
	public int Length { get; set; }

	public void Enqueue(int Value)
	{
		Node newNode = new Node(Value);

		if (this.Last == null)
        {
			this.Last = newNode;
			this.First = this.Last;
        }
		else
        {
			this.Last.Next = newNode;
			this.Last = newNode;
        }

		Length++;
	}

	public void Dequeue()
	{
		if (this.First != null)
        {
			this.First = this.First.Next;

			if (this.First == null) 
				this.Last = null;

			Length--;
        }
		else
        {
			Console.WriteLine("Nothing to dequeue.");
        }
	}

	public void Print()
	{
		if (this.First != null)
		{
			StringBuilder sb = new StringBuilder();
			Node curNode = this.First;

			while (curNode != null)
			{
				sb.Append(curNode.Value + " -> ");
				curNode = curNode.Next;
			}

			Console.WriteLine(sb.ToString());
			Console.WriteLine($"First: {this.First.Value}");
			Console.WriteLine($"Last: {this.Last.Value}");
			Console.WriteLine($"Length: {this.Length}");
		}
		else
		{
			Console.WriteLine("Stack is empty.");
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