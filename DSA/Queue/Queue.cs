namespace DSA.Queue;

// Queue is a linear data structure that follows the First In First Out (FIFO) principle.
// Elements are added to the end of the queue and removed from the front.
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

    // Enqueue adds a new element to the end of the queue.
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
        Node temp = first; // Store the first node to return it later
        if (length == 1)
        {
            first = null;
            last = null;
        }
        else
        {
            first = first.next; // Move the first pointer to the next node
            temp.next = null; // Clear the next pointer of the dequeued node
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