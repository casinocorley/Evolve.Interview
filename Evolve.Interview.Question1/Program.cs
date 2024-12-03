int[] Question1(int a, int b)
{
    /*
        This function, given two positive integer value parameters, will print out all 
        even numbers between 2 and the highest parameter value (inclusive) which is evenly 
        divisible by the lowest parameter value.

        Examples:
        - Given 17 and 4, the output will be 4, 8, 12, 16
        - Given 21 and 7, the output will be 14
        - Given 5 and 20, the output will be 10, 20
        - Given 3 and 10, the output will be 6
        - Given 2 and 2, the output will be 2
    */

    if(a <= 0 || b <= 0)
        throw new ArgumentException("parameters must be positive");

    var orderParams = new List<int> { a, b }
        .OrderBy(x => x)
        .ToArray();

    var min = orderParams[0];
    var max = orderParams[1];
    var answers = new List<int>();

    for(int x = min; x <= max; x+=min)
    {
        if (x % 2 == 0)
            answers.Add(x);
    }

    return answers.ToArray();
}

void PrintQuestion1(int a, int b)
{
    var output = Question1(a, b);
    Console.WriteLine($"Given {a} and {b}, the output is {string.Join(", ", output)}");
}


PrintQuestion1(17, 4);
PrintQuestion1(21, 7);
PrintQuestion1(5, 20);
PrintQuestion1(3, 10);
PrintQuestion1(2, 2);

