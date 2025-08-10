namespace DSA.BST;

// Binary Search Tree implementation in C#
// Binary Search Trees (BST) are a type of data structure that
// maintains sorted order of elements. Each node in a BST has a value,
// and all values in the left subtree are less than the node's value,
// while all values in the right subtree are greater than the node's value.

public class BinarySearchTree
{
    // The root node of the BST
    public Node root;

    // Inserts a new value into the BST.
    public bool Insert(int value)
    {
        Node newNode = new Node(value);
        // If the tree is empty, set the new node as the root
        if (root == null)
        {
            root = newNode;
            return true;
        }
        // Otherwise, find the correct position for the new node
        // by traversing the tree
        Node temp = root;
        while (true)
        {
            // If the value already exists, return false
            if (newNode.value == temp.value) return true;
            // If the new value is less than the current node's value,
            // go to the left subtree; otherwise, go to the right subtree
            if (newNode.value < temp.value)
            {
                // If the left child is null, insert the new node here
                if (temp.left == null)
                {
                    temp.left = newNode;
                    return true;
                }
                // Move to the left child
                temp = temp.left;
            }
            else
            {
                // If the right child is null, insert the new node here
                if (temp.right == null)
                {
                    temp.right = newNode;
                    return true;
                }
                // Move to the right child
                temp = temp.right;
            }
        }
    }

    // Contains checks if a value exists in the BST.
    public bool Contains(int value)
    {
        // If the tree is empty, return false
        if (root == null) return false;
        Node temp = root;
        // Traverse the tree to find the value
        while (temp != null)
        {
            // If the value is found, return true
            if (value < temp.value)
                temp = temp.left; // If the value is less, go left
            else if (value > temp.value)
                temp = temp.right; // If the value is greater, go right
            else
                return true; // If the value matches, return true
        }
        return false;
    }
    
    // Remove deletes a value from the BST.
}

public class Node
{
    public int value;
    public Node left;
    public Node right;
    
    public Node (int value) 
    {
        this.value = value;
    }
}