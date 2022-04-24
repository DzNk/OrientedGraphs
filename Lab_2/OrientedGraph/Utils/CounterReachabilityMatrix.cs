namespace Lab_2.OrientedGraph.Utils;

public class CounterReachabilityMatrix
{
    private bool[,] Data { get; }

    private int N { get; }

    public CounterReachabilityMatrix(ReachabilityMatrix input)
    {
        N = input.N;
        Data = new bool[N, N];
        for (int i = 0; i < input.N; i++)
        for (int j = 0; j < input.N; j++)
            Data[i, j] = input.Data[j, i];
    }

    public void Display()
    {
        Console.Write("".PadRight(3));
        for (var i = 0; i < N; i++) Console.Write("[{0}]".PadLeft(6), i + 1);
        Console.WriteLine();
        for (var i = 0; i < N; i++)
        {
            Console.Write("[{0}]".PadLeft(3), i + 1);
            for (var j = 0; j < N; j++) Console.Write("{0}".PadLeft(6), Convert.ToInt32(Data[i, j]));
            Console.WriteLine();
        }
    }
}