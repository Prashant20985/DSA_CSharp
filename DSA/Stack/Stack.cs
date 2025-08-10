namespace DSA.Stack;

// Stack is a linear data structure that follows the Last In First Out (LIFO) principle.
// Elements are added to the top of the stack and removed from the top.
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

    // Push adds a new element to the top of the stack.
    public void Push(int value)
    {
        Node newNode = new Node(value);
        if (height != 0) 
            newNode.next = top; // link the new node to the current top
        top = newNode; // make the new node the top of the stack
        height++;
    }

    public Node Pop()
    {
        if (height == 0) return null;
        Node temp = top;
        top = top.next; // Move the top pointer to the next node
        temp.next = null; // Clear the next pointer of the popped node
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