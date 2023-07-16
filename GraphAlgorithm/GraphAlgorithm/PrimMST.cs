namespace GraphAlgorithm;
public class PrimMST
{
    private static readonly List<char> _labels = Enumerable.Range(1, 6)
                               .Select(i => (char)(i + 48))
                               .ToList();
    public static void FindMinimumSpanningTree(List<List<double>> graph)
    {
        var verticesCount = graph.Count;
        var selectedEdgesCount = default(int);
        var selected = new List<bool>(new bool[verticesCount]);
        selected[0] = true;
        while (selectedEdgesCount < verticesCount - 1)
        {
            FindNextVertexWithMinimumEdge(graph, selected, verticesCount, ref selectedEdgesCount);
        }
    }
    private static void FindNextVertexWithMinimumEdge(List<List<double>> graph, List<bool> selected, int verticesCount, ref int selectedEdgesCount)
    {
        var minimum = double.MaxValue;
        var tempFrom = default(int);
        var tempTo = default(int);
        for (int i = 0; i < verticesCount; i++)
        {
            if (selected[i])
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (IsValidVertex(i, j, graph, minimum, selected[j]))
                    {
                        minimum = graph[i][j];
                        tempFrom = i;
                        tempTo = j;
                    }
                }
            }
        }
        selected[tempTo] = true;
        selectedEdgesCount++;
        PrintVertix(_labels[tempFrom], _labels[tempTo], graph[tempFrom][tempTo]);
    }

    private static void PrintVertix(char from, char to, double graphValue)
    {
        Console.Write($"{from} - ");
        Console.Write($"{to} : ");
        Console.WriteLine($"{graphValue}");
    }
    private static bool IsValidVertex(int fromIndex, int toIndex, List<List<double>> graph, double minimum, bool selected)
    {
        var vertexIsNotSelected = selected is false;
        var weigthBetweenVertexAndTheNextIsGreaterThanZero = graph[fromIndex][toIndex] > 0;
        var weigthBetweenVertexAndTheNextIsLessThanTheCurrentMinimumValue = graph[fromIndex][toIndex] < minimum;
        return vertexIsNotSelected && weigthBetweenVertexAndTheNextIsGreaterThanZero
                                   && weigthBetweenVertexAndTheNextIsLessThanTheCurrentMinimumValue;
    }
}
