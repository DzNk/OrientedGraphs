using Lab_2.OrientedGraph.Gfx;
using Lab_2.OrientedGraph.Utils;

namespace Lab_2
{
    internal enum FillTypes
    {
        Manual,
        Random
    }

    internal static class Program
    {
        private struct WorkingValues
        {
            public int N { get; set; }
            public int M { get; set; }
            public int K { get; set; }
            public int Option { get; set; }
        }

        private static void Main()
        {
            WorkingValues workingValues = new WorkingValues();
            GetWorkingValues(ref workingValues);
            AdjacencyMatrix adjacencyMatrix = new(workingValues.N);
            switch (workingValues.Option)
            {
                case (int) FillTypes.Manual:
                    adjacencyMatrix.ManualFill(workingValues.M);
                    break;
                case (int) FillTypes.Random:
                    adjacencyMatrix.RandomFill(workingValues.M);
                    break;
            }

            //first task
            Console.Clear();
            Graphics orientedGraph = new(1000, 1000, "Oriented Graph");
            DisplayGeneratedGraph(orientedGraph, adjacencyMatrix);

            //second task
            Console.Clear();
            AdjacencyMatrix lastKMatrix = adjacencyMatrix.TrimToKLastElements(workingValues.K);
            orientedGraph = new(1000, 1000, "oriented graph");
            DisplayGeneratedGraph(orientedGraph, lastKMatrix);

            //third task
            Console.Clear();
            SumMatrix[] matrices = new SumMatrix[workingValues.N - 1];
            for (int i = 0; i < workingValues.N - 1; i++)
            {
                matrices[i] = new(adjacencyMatrix);
                matrices[i] = matrices[i].Pow(i + 2);
                Console.WriteLine("S^{0}", i + 2);
                matrices[i].Display();
                Console.ReadKey();
                Console.Clear();
            }

            //forth task
            Console.Clear();
            SumMatrix sum = new(workingValues.N);
            for (int i = 0; i < workingValues.N - 1; i++) sum += matrices[i];
            Console.WriteLine("S[E]");
            sum.Display();
            Console.ReadKey();
            
            //fifth task
            Console.Clear();
            Console.WriteLine("Матрица R: ");
            ReachabilityMatrix reachabilityMatrix = new(adjacencyMatrix);
            reachabilityMatrix.Display();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Матрица Q: ");
            CounterReachabilityMatrix counterReachabilityMatrix = new(reachabilityMatrix);
            counterReachabilityMatrix.Display();
            Console.ReadKey();
            
            //sixth task
            Console.Clear();
            sum.PrintMaxElementConnections();
            Console.ReadKey();
        }

        private static void DisplayGeneratedGraph(Graphics graph, AdjacencyMatrix matrix)
        {
            graph.SetBackgroundColor(32, 32, 32);
            graph.CreateGraph(matrix);
            Console.WriteLine("Матрица смежности построенного графа");
            matrix.Display();
            Console.WriteLine("Нажмите enter для вывода графа");
            Console.ReadKey();
            graph.Run();
        }

        private static void GetWorkingValues(ref WorkingValues values)
        {
            Console.WriteLine("Введите значение n:");
            values.N = GetValueFromKeyboard(3, 6);
            Console.WriteLine("Введите значение m:");
            values.M = GetValueFromKeyboard(2, 2 * values.N);
            Console.WriteLine("Введите значение k:");
            values.K = GetValueFromKeyboard(1, values.N - 1);
            Console.WriteLine("Выберите вариант заполнения матрицы смежности:");
            Console.WriteLine("[{0}] - Ручной", (int) FillTypes.Manual);
            Console.WriteLine("[{0}] - Случайный", (int) FillTypes.Random);
            values.Option = GetValueFromKeyboard((int) FillTypes.Manual, (int) FillTypes.Random);
        }

        private static int GetValueFromKeyboard(int startLimit, int endLimit)
        {
            int value;
            Console.WriteLine("Введите число из диапазона [{0} : {1}]", startLimit, endLimit);
            var userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out value) || (value < startLimit || value > endLimit))
            {
                Console.WriteLine("Введите корректное значение: ");
                userInput = Console.ReadLine();
            }

            return value;
        }
    }
}