namespace Lab_2.OrientedGraph.Utils;

public class AdjacencyMatrix
{
    public bool[,] Data { set; get; }
    public int N { get; }

    public AdjacencyMatrix(int n)
    {
        N = n;
        Data = new bool[n, n];
    }

    public AdjacencyMatrix TrimToKLastElements(int k)
    {
        var tempArray = new AdjacencyMatrix(k);
        for (int i = N - k, l = 0; i < N; i++, l++)
            for (int j = N - k, m = 0; j < N; j++, m++)
                tempArray.Data[l, m] = Data[i, j];
        return tempArray;
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

    public void ManualFill(int m)
    {
        var i = 0;
        for (var j = 0; j < N; j++)
        {
            for (var k = 0; k < N; k++)
            {
                if (j != k)
                {
                    var value = _getValueFromKeyboard(0, 1);
                    Data[j, k] = Convert.ToBoolean(value);
                    if (Data[j, k]) i++;
                    Display();
                }

                if (i == m) break;
            }

            if (i == m) break;
        }
    }

    public void RandomFill(int m)
    {
        List<int> indexes = new();
        indexes.Add(1);
        int cntr = 0;
        while (cntr < m)
        {
            Random rnd = new();
            int element = rnd.Next(1, N * N);
            while (indexes.IndexOf(element) != -1)
                element = rnd.Next(1, N * N);
            indexes.Add(element);

            var i = 1;
            var buff = element;
            while (buff > N) { buff -= N; i++; }
            var j = element;
            while (j > N) j -= N;
            if (i == j) continue;
            
            i--;
            j--;
            Data[i, j] = true;
            cntr++;
        }
    }

    public AdjacencyMatrix Pow(int power)
    {
        if (power == 1) return this;

        AdjacencyMatrix temp = new(N) { Data = Data };
        for (var i = 1; i < power; i++) temp += _multiplyOnSelf(temp);
        return temp;
    }

    private AdjacencyMatrix _multiplyOnSelf(AdjacencyMatrix input)
    {
        AdjacencyMatrix temp = new(input.N);
        for (var i = 0; i < N; i++)
            for (var j = 0; j < N; j++)
                for (var k = 0; k < N; k++)
                {
                    temp.Data[i, j] |= input.Data[i, k] && Data[k, j];
                    if (temp.Data[i, j]) break;
                }

        return temp;
    }

    private static int _getValueFromKeyboard(int startLimit, int endLimit)
    {
        int value;
        Console.WriteLine("Введите число из диапазона [{0} : {1}]", startLimit, endLimit);
        var userInput = Console.ReadLine();
        while (!int.TryParse(userInput, out value) || value < startLimit || value > endLimit)
        {
            Console.WriteLine("Введите корректное значение: ");
            userInput = Console.ReadLine();
        }

        return value;
    }

    public static AdjacencyMatrix operator +(AdjacencyMatrix a, AdjacencyMatrix b)
    {
        AdjacencyMatrix sum = new(a.N);
        for (var i = 0; i < a.N; i++)
            for (var j = 0; j < a.N; j++)
                sum.Data[i, j] |= a.Data[i, j] | b.Data[i, j];
        return sum;
    }
}