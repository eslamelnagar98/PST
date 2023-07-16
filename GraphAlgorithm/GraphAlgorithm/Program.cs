namespace GraphAlgorithm;
internal class Program
{
    //ref int bucket = ref Unsafe.NullRef<int>();
    private static readonly List<List<double>> _graph = new()
        {
           new List<double> { 0, 6.7, 5.2, 2.8, 5.6, 3.6 },
           new List<double> { 6.7, 0, 5.7, 7.3, 5.1, 3.2 },
           new List<double> { 5.2, 5.7, 0, 3.4, 8.5, 4.0 },
           new List<double> { 2.8, 7.3, 3.4, 0, 8, 4.4   },
           new List<double> { 5.6, 5.1, 8.5, 8, 0, 4.6   },
           new List<double> { 3.6, 3.2, 4, 4.4, 4.6, 0   }
        };
    static void Main(string[] args)
    {
        //PrimMST.FindMinimumSpanningTree(_graph);
        var vertixCount = 9;
        var graphDictionary = new Dictionary<char, List<char>>(vertixCount)
        {
            { 'A',new List<char>{'B','C' } },
            { 'B',new List<char>{'E','D','A' } },
            { 'C',new List<char>{'A','D','B','F' } },
            { 'D',new List<char>{'B','C','F' } },
            { 'E',new List<char>{'B','F' } },
            { 'F',new List<char>{'C','D','E','H' } },
            { 'H',new List<char>{'G','I','F' } },
            { 'I',new List<char>{'G','H' } },
        };

        var queue = new Queue<char>(vertixCount);
        queue.Enqueue('A');
        var visited = new Dictionary<char, bool>(vertixCount) { { 'A', true } };

        var currentVertex = default(char);
        var destinations = new List<char>();
        while (queue.Count is not 0)
        {
            currentVertex = queue.Dequeue();
            destinations = graphDictionary.GetValueOrDefault(currentVertex);
            for (int i = 0; i < destinations?.Count; i++)
            {
                if (!visited.ContainsKey(destinations[i]))
                {
                    queue.Enqueue(destinations[i]);
                    visited.Add(destinations[i], true);
                    Console.WriteLine($"{currentVertex}-{destinations[i]}");
                }
            }
        }

    }

}

