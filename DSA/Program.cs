// See https://aka.ms/new-console-template for more information

using DSA.LinkedList;
using DSA.Random;
using DSA.Recursion;
using DSA.Stack;

// LinkedListDemo myLinkedList = new LinkedListDemo(1);
// myLinkedList.Append(2);
// myLinkedList.Append(3);
// myLinkedList.Append(4);
//
// myLinkedList.Print();
//
// myLinkedList.Reverse();
// Console.WriteLine();
// myLinkedList.Print();

// Stack stack = new Stack(0);
// stack.Push(1);
// stack.Push(2);
// stack.Push(3);
//
// stack.Print();

// Factorial factorial = new Factorial();
// int myFactorial = factorial.CalculateFactorial(4);
// Console.WriteLine(myFactorial);

RandomProblems rp = new RandomProblems();
var reverseString = rp.ReverseStringWithoutArray("Yellow");
Console.WriteLine(reverseString);