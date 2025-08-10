namespace DSA.LinkedList;

public class LinkedListDemo
{
    private Node head;
    private Node tail;
    private int length;

    public LinkedListDemo(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }

    public void Append(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }

        length++;
    }

    public Node RemoveLast()
    {
        if (length == 0) return null;
        Node temp = head;
        Node pre = head;

        while (temp.next != null)
        {
            pre = temp;
            temp = temp.next;
        }
        tail = pre;
        tail.next = null;
        length--;
        if (length == 0)
        {
            head = null;
            tail = null;
        }
        return temp;
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);
        if (length is 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.next = head;
            head = newNode;
        }
        length++;
    }

    public Node RemoveFirst()
    {
        if (length is 0) return null;
        Node temp = head;
        head = head.next;
        temp.next = null;
        length--;
        if (length is 0)
        {
            head = null;
            tail = null;
        }
        return temp;
    }

    public Node Get(int index)
    {
        if (index < 0 || index >= length) return null;
        Node temp = head;

        for (int i = 0; i < index; i++)
        {
            temp = temp.next;
        }
        return temp;
    }

    public bool Set(int index, int value)
    {
        Node temp = Get(index);
        if (temp is not null)
        {
            temp.value = value;
            return true;
        }
        return false;
    }

    public bool Insert(int index, int value)
    {
        if (index < 0 || index > length) return false;
        if (index is 0)
        {
            Prepend(value);
            return true;
        }
        if (index == length)
        {
            Append(value);
            return true;
        }
        Node newNode = new Node(value);
        Node temp = Get(index - 1);
        newNode.next = temp.next;
        temp.next = newNode;
        length++;
        return true;
    }

    public Node Remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return RemoveFirst();
        if (index == length - 1) return RemoveLast();

        Node prev = Get(index - 1);
        Node temp = prev.next;
        prev.next = temp.next;
        temp.next = null;
        length--;
        return temp;
    }

    public void Reverse()
    {
        Node temp = head;
        head = tail;
        tail = temp;
        Node after = temp.next;
        Node before = null;

        for (int i = 0; i < length; i++)
        {
            after = temp.next;
            temp.next = before;
            before = temp;
            temp = after;
        }
    }

    public void Print()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.value + ", ");
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