namespace DSA.Queue;

public class Queue
{
    private Node first;
    private Node last;
    private int length;

    public Queue(int value)
    {
        Node newNode = new Node(value);
        first = newNode;
        last = newNode;
        length = 1;
    }

    public void Enqueue(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            first =  newNode;
            last = newNode;
        }
        else
        {
            last.next = newNode;
            last = newNode;
        }
        length++;
    }

    public Node Dequeue()
    {
        if (length == 0) return null;
        Node temp = first;
        if (length == 1)
        {
            first = null;
            last = null;
        }
        else
        {
            first = first.next;
            temp.next = null;
        }
        length--;
        return temp;
    }
    
    public void PrintQueue()
    {
        Node temp = first;
        while (temp != null)
        {
            Console.WriteLine(temp.value);
            temp = temp.next;
        }
    }
}

public class Node
{
    public int value;
    public Node next;

    public Node(int value)
    {
        this.value = value;
    }
}