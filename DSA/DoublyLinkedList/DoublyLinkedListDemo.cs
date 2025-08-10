namespace DSA.DoublyLinkedList;

// Doubly Linked List implementation in C#
// A Doubly Linked List is a data structure where each node contains a value
// and pointers to both the next and previous nodes. This allows traversal
// in both directions, making it more flexible than a singly linked list.
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

    // Appends a new value to the end of the list.
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
            tail.next = newNode; // Link the new node to the end
            newNode.prev = tail; // Link the end node to the new node
            tail = newNode; // Update the tail to the new node
        }
        length++;
    }

    public Node RemoveLast()
    {
        if (length == 0) return null;
        Node temp = tail; // Store the current tail node to return it later
        if (length == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.prev; // Move the tail pointer to the previous node
            tail.next = null; // Disconnect the old tail
            temp.prev = null; // Clear the previous pointer of the removed node
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
        if (index < length / 2) // If the index is in the first half, traverse from the head
        {
            for (int i = 0; i < index; i++) // Traverse from the head to the index
            {
                temp = temp.next;
            }
        }
        else
        {
            for (int j = length - 1; j > index; j--) // Traverse from the tail to the index
            {
                temp = temp.prev;
            }
        }
        return temp; // Return the node at the specified index
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
        if (index < 0 || index > length) return false; // Check if the index is valid, if its less than 0 or greater than length, return false
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
        Node before = Get(index - 1); // Get the node before the index
        Node after = before.next; // Get the node after the index
        
        before.next = newNode; // Link the new node after the before node
        after.prev = newNode; // Link the new node before the after node
        newNode.next = after; // Link the new node to the after node
        newNode.prev = before; // Link the new node to the before node
        length++;
        return true;
    }

    public Node Remove(int index)
    {
        if (index < 0 || index >= length) return null;
        if (index == 0) return RemoveFirst();
        if (index == length - 1) return RemoveLast();
        Node temp = Get(index); // Get the node at the specified index
        temp.prev.next = temp.next; // Link the previous node to the next node
        temp.next.prev = temp.prev; // Link the next node to the previous node
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