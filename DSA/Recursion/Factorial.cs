namespace DSA.Recursion;

public class Factorial
{
    public int CalculateFactorial(int number)
    {
        if (number == 1) return 1;
        return number * CalculateFactorial(number - 1);
    }
}