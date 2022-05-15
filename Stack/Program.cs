using System.Text;

MyStack myStack = new MyStack();
myStack.Push(1);
myStack.Push(2);
myStack.Push(3);
myStack.Push(4);

myStack.Print();

myStack.Pop();
myStack.Peak();
myStack.Pop();
myStack.Peak();
myStack.Pop();
myStack.Peak();
myStack.Pop();
myStack.Peak();


Console.ReadLine();




public class MyStack
{
	public Node Top { get; set; }
	public Node Last { get; set; }
	public int Length { get; set; }

	public void Push(int Value)
	{
		Node newNode = new Node(Value);

		if (this.Top == null)
        {
			this.Top = newNode;
			this.Last = newNode;
        }
		else
        {
			newNode.Next = this.Top;
			this.Top = newNode;
        }
		
		this.Length++;
	}

	public void Pop()
	{
		if (this.Top == null)
        {
			Console.WriteLine("Nothing to pop.");
        }
		else
        {
			this.Top = this.Top.Next;
			this.Length--;
        }
	}

	public void Peak()
    {
		Console.WriteLine($"Top Node: {this.Top?.Value}");
    }

	public void Print()
	{
		if (this.Top != null)
		{
			StringBuilder sb = new StringBuilder();
			Node curNode = Top;

			while (curNode != null)
			{
				sb.Append(curNode.Value + " -> ");
				curNode = curNode.Next;
			}

			Console.WriteLine(sb.ToString());
			Console.WriteLine($"Top: {this.Top.Value}");
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