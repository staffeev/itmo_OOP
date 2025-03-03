using System.Xml;

struct Edge {
    public int i, j;
    public long weight;
    public override string ToString() {
        return $"Edge(i={i}, j={j}, weight={weight})";
    }
}


class Graph {
    public Dictionary<int, List<Edge>> edges_list;
    public Dictionary<int, Dictionary<int, long>> edges_dict;
    public List<Edge> edges;
    public int n;

    public Graph() { }

    public Graph(Dictionary<int, List<Edge>> edges_list) { 
        this.edges_list = edges_list;
        this.n = NodesCount(edges_list);
    }

    public static Graph CreateGraph() {
        Console.Write("Введите количество ребер: ");
        int m  = Int32.Parse(Console.ReadLine());
        var edges = new Dictionary<int, List<Edge>>();
        Console.Write("Граф ориентированный? (true/false): ");
        bool oriented = bool.Parse(Console.ReadLine());
        Console.WriteLine("Вводите ребра в формате 'i j w', где i, j - 1-я и 2-я вершины, w - вес ребра");
        for (int k = 0; k < m; k++) {
            string[] args = Console.ReadLine().Split();
            int i = Int32.Parse(args[0]);
            int j = Int32.Parse(args[1]);
            int weight;
            try
            {
                weight = Int32.Parse(args[2]);
            }
            catch (IndexOutOfRangeException) {
                weight = 1;
            }
            // добавление ребра
            if (!edges.ContainsKey(i)) {
                edges[i] = new List<Edge>();
            }
            var e = new Edge { i = i, j = j, weight = weight };
            edges[i].Add(e);
            if (oriented) { continue;  }
            if (!edges.ContainsKey(j))
            {
                edges[j] = new List<Edge>();
            }
            edges[j].Add(new Edge { i = j, j = i, weight = weight });
            
        }
        return new Graph(edges);
    }

    public void CreateSimpleEdges() {
        var simple_edges = new List<Edge>();
        foreach (int i in edges_list.Keys)
        {
            foreach (Edge e in edges_list[i])
            {
                simple_edges.Add(e);
            }
        }
        this.edges = simple_edges;
    } 

    public void CreateEdgesDict() { 
        var edges_dict = new Dictionary<int, Dictionary<int, long>>();
        foreach (int i in edges_list.Keys) {
            foreach (Edge e in edges_list[i]) {
                if (!edges_dict.ContainsKey(i)) {
                    edges_dict[i] = new Dictionary<int, long>();
                }
                edges_dict[i][e.j] = e.weight; 
            }
        }
        this.edges_dict = edges_dict;
    }

    public static int NodesCount(Dictionary<int, List<Edge>> edges_list)
    {
        int maxNode = 0;
        foreach (int i in edges_list.Keys) {
            foreach (Edge e in edges_list[i]) {
                var args = new[] { maxNode, i, e.i, e.j };
                maxNode = args.Max();
            }
        }
        return maxNode;
    }

    public void PrintEdges() {
        foreach (int i in edges_list.Keys) {
            foreach (Edge e in edges_list[i]) {
                Console.WriteLine(e.ToString());
            }
        }
    }

}

class Algorithms {
    private static void _DFS(int start_node, Graph g, bool[] visited)
    {
        visited[start_node] = true;
        Console.Write("{0} ", start_node);
        var cur_edges = new List<Edge>();
        if (!g.edges_list.TryGetValue(start_node, out cur_edges)) { return; }
        foreach (Edge e in cur_edges)
        {
            if (g.edges_list.ContainsKey(e.j) && !visited[e.j])
            {
                _DFS(e.j, g, visited);
            }
        }
    }
    public static void DFS(int start_node, Graph g, bool[] visited) {
        _DFS(start_node, g, visited);
        Console.WriteLine();
    }

    public static void BFS(int start_node, Graph g, bool[] visited)
    {
        var queue = new Queue<int>();
        visited[start_node] = true;
        queue.Enqueue(start_node);
        while (queue.Count > 0) {
            int cur_node = queue.Dequeue();
            Console.Write("{0} ", cur_node);
            var cur_edges = new List<Edge>();
            if (!g.edges_list.TryGetValue(cur_node, out cur_edges)) { continue; }
            foreach (Edge e in cur_edges)
            {
                if (g.edges_list.ContainsKey(e.j) && !visited[e.j])
                {
                    visited[e.j] = true;
                    queue.Enqueue(e.j);
                }
            }
        }
        Console.WriteLine();

    }
    public static void Dijkstra(int cur_node, Graph g, out long[] final_distances, out Dictionary<int, int> final_prev_nodes)
    {
        g.CreateEdgesDict();
        var distances = Enumerable.Repeat((long)Math.Pow(10, 9), g.n + 1).ToArray();
        distances[cur_node] = 0;
        bool[] marked = new bool[g.n + 1];
        marked[cur_node] = true;
        int unmarked = g.n;
        var previous_nodes = new Dictionary<int, int>();

        while (unmarked > 0) {
            var neighbours = GetNeighbours(cur_node, g, marked);
            foreach (int neigh in neighbours)
            {
                long prev_dist = distances[neigh];
                long new_dist = distances[cur_node] + g.edges_dict[cur_node][neigh];
                if (new_dist < prev_dist) {
                    distances[neigh] = new_dist;
                    previous_nodes[neigh] = cur_node;
                }
            }
            cur_node = GetMinLabelNode(distances, marked);
            marked[cur_node] = true;
            unmarked--;
        }
        final_distances = distances;
        final_prev_nodes = previous_nodes;
    }

    public static List<int> GetNeighbours(int node, Graph g, bool[] marked)
    {
        var neighbours = new List<int>();
        foreach (Edge e in g.edges_list[node]) {
            if (marked[e.j]) { continue; }
            neighbours.Add(e.j);
        }
        return neighbours;
    }

    public static int GetMinLabelNode(long[] distances, bool[] marked) {
        long min_label = (long)Math.Pow(10, 9);
        int argmin = 0;
        for (int i = 0; i < marked.Length; i++) {
            if (marked[i]) { continue; }
            if (distances[i] < min_label) { 
                min_label = distances[i];
                argmin = i;
            }

        }
        return argmin;
    }

    public static List<Edge> Kruskal(Graph g) {
        g.CreateSimpleEdges();
        var edges = g.edges;
        edges = edges.OrderBy(e => e.weight).ToList();

        var used = new HashSet<int>();
        var groups = new Dictionary<int, HashSet<int>>();
        var MST = new List<Edge>();

        foreach (Edge e in edges) { // создаем изолированные группы
            if (used.Contains(e.i) && used.Contains(e.j)) { continue; } // избегаем цикла
            if (!used.Contains(e.i) && !used.Contains(e.j)) // обе вершины изолированы
            {
                var group = new HashSet<int> { e.i, e.j };
                groups[e.i] = group;
                groups[e.j] = group;
            }
            else if (!used.Contains(e.i)) // первая изолирована
            {
                groups[e.j].Add(e.i);
                groups[e.i] = groups[e.j];
            }
            else if (!used.Contains(e.j)) { // вторая изолирована
                groups[e.i].Add(e.j);
                groups[e.j] = groups[e.i];
            }
            MST.Add(e);
            used.Add(e.i);
            used.Add(e.j);
        }
        foreach (Edge e in edges) { // объединяем группы
            if (!groups[e.i].Contains(e.j)) { 
                MST.Add(e);
                var group = groups[e.i];
                groups[e.i].UnionWith(groups[e.j]);
                groups[e.j].UnionWith(group);

            }
        }
        return MST;
    }

    public static void PrintMinCostPath(int start_node, int end_node, Dictionary<int, int> prevs)
    {
        var path = new List<int>();
        while (end_node != start_node)
        {
            path.Add(end_node);
            end_node = prevs[end_node];
        }
        path.Add(start_node);
        path.Reverse();
        for (int i = 0; i < path.Count - 1; i++)
        {
            Console.Write("{0} -> ", path[i]);
        }
        Console.Write("{0}\n", path[path.Count - 1]);
    }
}

class Program {
    public static void Main() {
        var g = Graph.CreateGraph();
        bool[] visited = new bool[g.n + 1];
        Console.WriteLine("В результате обхода в глубину вершины графа были пройдены в следующем порядке:");
        Algorithms.DFS(0, g, visited);
        visited = new bool[g.n + 1];
        Console.WriteLine("В результате обхода в ширину вершины графа были пройдены в следующем порядке:");
        Algorithms.BFS(0, g, visited);

        var distances = new long[g.n + 1];
        var prevs = new Dictionary<int, int>();
        int start_node = 0;
        int end_node = 9;
        Algorithms.Dijkstra(start_node, g, out distances, out prevs);
        Console.WriteLine("В результате работы алгоритма Дейкстры были определены минимальные пути от вершины {0}", start_node);
        foreach (long dist in distances)
        {
            Console.Write("{0} ", dist);
        }
        Console.WriteLine();
        Console.WriteLine("Кратчайший путь между вершинами {0} и {1}", start_node, end_node);
        Algorithms.PrintMinCostPath(start_node, end_node, prevs);
        foreach (int i in distances)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
        Console.WriteLine("В результате работы алгоритма Крускала минимальное остовное дерево составляют следующие ребра:");
        var edges = Algorithms.Kruskal(g);
        foreach (Edge e in edges) {
            Console.WriteLine(e);
        }
    }
}