using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
    public class AStar
    {
        private double omega;
        private PriorityQueue Open;
        private List<IVertex> Close;
        private double currentPathLength = 0;
        private IGraph graph;
        private IVertex start;
        private IVertex goal;
        bool firstRun = true;

        public AStar(double omega, IGraph graph, IVertex start, IVertex goal)
        {
            if (omega > 1 || omega < 0)
                throw new ArgumentException();
            this.omega = omega;
            this.graph = graph;
            this.start = start;
            this.goal = goal;
        }

        public List<IVertex> GetWay()
        {
            Open = new PriorityQueue();
            Close = new List<IVertex>();
            var s = new List<IVertex>();
            s.Add(start);
            Open.Add(FFunction(s), s);
            while (Open.Count!=0)
            {
                // Выбираем наилучший путь из очереди
                var p = Open.First();
                Open.RemoveFirst();
                // Рассматриваем его последнюю вершину
                var x = p.Last();
                // Если она уже была посещена, отбрасываем этот путь
                if (Close.Contains(x))
                    continue;
                // Если это целевая вершина, сохраним стоимость пути и вернем его
                if (x.Equals(goal))
                {
                    currentPathLength = 0;
                    for (int i = 1; i < p.Count; i++)
                        currentPathLength += graph.Cost(p[i], p[i - 1]);
                    firstRun = false;
                    return p;
                }
                // Отмечаем текущую вершину как посещенную
                Close.Add(x);
                // Раскрываем непосещенные смежные вершины
                foreach (var y in graph.Adjacent(x))
                    if (!Close.Contains(y))
                    {
                        var newPath = new List<IVertex>(p);
                        newPath.Add(y);
                        // Если это первый запуск, то алгоритм работает, как стандартный алгоритм А*
                        // Иначе отбрасываем потенциальные пути, для которых допустимая функция дает оценку, большую, чем стоимость последнего найденного пути
                        if (firstRun || FAccessibleFunction(newPath) < currentPathLength)
                            Open.Add(FFunction(newPath), newPath);
                    }
            }
            // Если путь не нашелся, выбрасываем исключение
            throw new Exception();
        }

        // Недопустимая функция оценки стоимости пути
        public double FFunction(List<IVertex> path)
        {
            double g = 0;
            for (int i = 1; i < path.Count; i++)
                g += graph.Cost(path[i - 1], path[i]);
            return (1 - omega) * g + omega * path.Last().HFunction();
        }

        // Вспомогательная допустимая функция оценки стоимости пути
        public double FAccessibleFunction(List<IVertex> path)
        {
            double g = 0;
            for (int i = 1; i < path.Count; i++)
                g += graph.Cost(path[i], path[i - 1]);
            return g + path.Last().HFunction();
        }
    }
}