namespace Lab_2.OrientedGraph.Utils;

public class SumMatrix
{
    public int[,] Data { get; }

    public int N { get; }

    public SumMatrix(int n)
    {
        N = n;
        Data = new int[N, N];
    }

    public SumMatrix(AdjacencyMatrix input)
    {
        N = input.N;
        Data = new int[N, N];
        for (var i = 0; i < input.N; i++)
            for (var j = 0; j < input.N; j++)
                Data[i, j] = Convert.ToInt32(input.Data[i, j]);
    }

    public void Display()
    {
        string title = " ".PadLeft(3);
        for (var i = 0; i < N; i++) title += String.Format("[{0}]", i + 1).PadLeft(5);
        Console.WriteLine(title);
        for (var i = 0; i < N; i++)
        {
            string line = String.Format("[{0}]", i + 1);
            for (var j = 0; j < N; j++) line += String.Format("{0}", Convert.ToInt32(Data[i, j])).PadLeft(5);
            Console.WriteLine(line);
        }
    }

    public static SumMatrix operator +(SumMatrix a, SumMatrix b)
    {
        SumMatrix sum = new(a.N);
        for (var i = 0; i < a.N; i++)
            for (var j = 0; j < a.N; j++)
                sum.Data[i, j] += a.Data[i, j] + b.Data[i, j];
        return sum;
    }

    public SumMatrix Pow(int power)
    {
        if (power == 1) return this;

        SumMatrix temp = this;
        for (var i = 1; i < power; i++) temp = _multiplyOnSelf(temp);
        return temp;
    }

    private SumMatrix _multiplyOnSelf(SumMatrix input)
    {
        SumMatrix temp = new(N);
        for (var i = 0; i < N; i++)
            for (var j = 0; j < N; j++)
                for (var k = 0; k < N; k++)
                    temp.Data[i, j] += input.Data[i, k] * Data[k, j];

        return temp;
    }

    public int MaxElement()
    {
        int candidate = Data[0, 0];
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                if (Data[i, j] > candidate)
                    candidate = Data[i, j];

        return candidate;
    }

    public void PrintMaxElementConnections()
    {
        int element = MaxElement();
        if (element == 0) return;

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                if (Data[i, j] == element)
                    Console.WriteLine("Ребра [{0}] и [{1}] имеют [{2}] соединений",
                                        i + 1, j + 1, Data[i, j]);
    }
}