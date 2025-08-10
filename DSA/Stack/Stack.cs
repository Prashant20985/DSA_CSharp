namespace DSA.Stack;

public class Stack
{
    private Node top;
    private int height;

    public Stack(int value)
    {
        Node newNode = new Node(value);
        top = newNode;
        height++;
    }

    public void Push(int value)
    {
        Node newNode = new Node(value);
        if (height != 0) 
            newNode.next = top;
        top = newNode;
        height++;
    }

    public Node Pop()
    {
        if (height == 0) return null;
        Node temp = top;
        top = top.next;
        temp.next = null;
        height--;
        return temp;
    }

    public void Print()
    {
        Node temp = top;
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