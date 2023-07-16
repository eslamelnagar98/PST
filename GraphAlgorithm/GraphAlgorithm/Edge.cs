namespace GraphAlgorithm;
public class Edge
{
    public double Weight;
    public Vertex Source;
    public Vertex Target;

    public Edge(Vertex source, Vertex target, double weight = 0)
    {
        Source = source;
        Target = target;
        Weight = weight;
    }
}
