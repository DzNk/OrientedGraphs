namespace Lab_2.OrientedGraph.Utils;

public class ReachabilityMatrix
{
    public bool[,] Data { get; }

    public int N { get; }

    public ReachabilityMatrix(AdjacencyMatrix input)
    {
        AdjacencyMatrix reachability = new(input.N);
        for (int i = 0; i < input.N; i++) reachability += input.Pow(i + 1);
        N = input.N;
        Data = reachability.Data;
        for (int i = 0; i < N; i++)
            Data[i, i] = true;
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