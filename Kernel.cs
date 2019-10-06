using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_theoryOfDecide
{
    /// <summary>
    /// Класс ребро
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Вершина источник
        /// </summary>
        public int SourceVertex { get; private set; }

        /// <summary>
        /// Конечная вершина
        /// </summary>
        public int EndedVertex { get; private set; }

        /// <summary>
        /// Вес ребра
        /// </summary>
        public double Weight { get; private set; }
        public Edge(int Vertex1, int Vertex2, double Weight)
        {
            this.SourceVertex = Vertex1;
            this.EndedVertex = Vertex2;
            this.Weight = Weight;
        }
    }
    public static class Kernel
    {
        /// <summary>
        /// Алгоритм Прима
        /// </summary>
        /// <param name="coutOfVertex">Количество верщин</param>
        /// <param name="Edges">Ребра</param>
        public static List<Edge> AlgorithmByPrim(int coutOfVertex, List<Edge> Edges)
        {
            AlgorithmByPrim(coutOfVertex, Edges, out List<Edge> result);
            return result;
        }

        /// <summary>
        /// Алгоритм Прима
        /// </summary>
        /// <param name="coutOfVertex">Количество верщин</param>
        /// <param name="Edges">Ребра</param>
        /// <param name="Result">Выходной массив</param>
        public static void AlgorithmByPrim(int coutOfVertex, List<Edge> Edges, out List<Edge> Result)
        {
            Random rand = new Random();

            //инициализация выходного листа
            Result = new List<Edge>();

            //неиспользованные ребра
            List<Edge> nonUsedEdges = new List<Edge>(Edges);

            //использованные вершины
            List<int> usedVertex = new List<int>();

            //неиспользованные вершины
            List<int> nonUsedVertex = new List<int>();
            for (int i = 1; i <= coutOfVertex; i++)
                nonUsedVertex.Add(i);

            //выбираем случайную начальную вершину
            usedVertex.Add(rand.Next(1, coutOfVertex));
            nonUsedVertex.RemoveAt(usedVertex[0] - 1);

            while (nonUsedVertex.Count > 0)
            {
                int minEdge = -1; //номер наименьшего ребра
                //поиск наименьшего ребра
                for (int i = 0; i < nonUsedEdges.Count; i++)
                {
                    if (usedVertex.IndexOf(nonUsedEdges[i].SourceVertex) != -1 && nonUsedVertex.IndexOf(nonUsedEdges[i].EndedVertex) != -1 ||
                        usedVertex.IndexOf(nonUsedEdges[i].EndedVertex) != -1 && nonUsedVertex.IndexOf(nonUsedEdges[i].SourceVertex) != -1)
                    {
                        if (minEdge != -1)
                        {
                            if (nonUsedEdges[i].Weight < nonUsedEdges[minEdge].Weight)
                                minEdge = i;
                        }
                        else
                        {
                            minEdge = i;
                        }
                    }
                }
                //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
                if (usedVertex.IndexOf(nonUsedEdges[minEdge].SourceVertex) != -1)
                {
                    usedVertex.Add(nonUsedEdges[minEdge].EndedVertex);
                    nonUsedVertex.Remove(nonUsedEdges[minEdge].EndedVertex);
                }
                else
                {
                    usedVertex.Add(nonUsedEdges[minEdge].SourceVertex);
                    nonUsedVertex.Remove(nonUsedEdges[minEdge].SourceVertex);
                }
                //заносим новое ребро в дерево и удаляем его из списка неиспользованных
                Result.Add(nonUsedEdges[minEdge]);
                nonUsedEdges.RemoveAt(minEdge);
            }
        }
    }
}
