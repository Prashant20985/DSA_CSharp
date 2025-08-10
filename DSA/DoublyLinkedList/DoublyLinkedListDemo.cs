namespace DSA.DoublyLinkedList;

public class DoublyLinkedListDemo
{
    public Node head;
    public Node tail;
    public int length;

    public DoublyLinkedListDemo(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length++;
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
            newNode.prev = tail;
            tail = newNode;
        }
        length++;
    }

    public Node RemoveLast()
    {
        if (length == 0) return null;
        Node temp = tail;
        if (length == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.prev;
            tail.next = null;
            temp.prev = null;
        }
        length--;
        return temp; 
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);
        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            head.prev = newNode;
            newNode.next = head;
            head = newNode;
        }
        length++;
    }

    public Node RemoveFirst()
    {
        if (length == 0) return null;
        Node temp = head;
        if (length == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.next;
            head.prev = null;
            temp.next = null;
        }
        length--;
        return temp;
    }

    public Node Get(int index)
    {
        if (index < 0 || index >= length) return null;
        Node temp = head;
        if (index < length / 2)
        {
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
        }
        else
        {
            for (int j = length - 1; j > index; j--)
            {
                temp = temp.prev;
            }
        }
        return temp;
    }

    public bool Set(int index, int value)
    {
        Node temp = Get(index);
        if (temp != null)
        {
            temp.value = value;
            return true;
        }
        return false;
    }

    public bool Insert(int index, int value)
    {
        if (index < 0 || index > length) return false;
        if (index == 0)
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
        Node before = Get(index - 1);
        Node after = before.next;
        
        before.next = newNode;
        after.prev = newNode;
        newNode.next = after;
        newNode.prev = before;
        length++;
        return true;
    }

    public Node Remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return RemoveFirst();
        if (index == length - 1) return RemoveLast();
        Node temp = Get(index);
        temp.prev.next = temp.next;
        temp.next.prev = temp.prev;
        temp.next = null;
        temp.prev = null;
        length--;
        return temp;
    }
}

public class Node
{
    public Node next;
    public Node prev;
    public int value;

    public Node(int value)
    {
        this.value = value;
    }
}