namespace GraphAlgorithm;
public class Graph
{
	public List<Vertex> Vertices;
	public Graph(List<string> names)
	{
		Vertices = new List<Vertex>(new Vertex[names.Count]);
		FillVertexNames(names);
	}
	public void AddEdges(int vertexIndex, List<int> targets)
	{
		Vertices[vertexIndex].VertexLinks = new List<Edge>(targets.Count);
		Vertices[vertexIndex].VertexLinks.AddRange(GenerateVertexEdges(vertexIndex, targets));
	}

	private void FillVertexNames(List<string> names)
	{
		for (int i = 0; i < names.Count; i++)
		{
			Vertices[i].Name = names[i];
		}
	}

	private IEnumerable<Edge> GenerateVertexEdges(int vertexIndex, List<int> target)
	{
		for (int i = 0; i < target.Count; i++)
		{
			yield return new Edge(Vertices[vertexIndex], Vertices[target[i]]);
		}
	}
}
