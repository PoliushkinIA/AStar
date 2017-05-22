using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
    public interface IGraph
    {
        // Список вершин, смежных с данной
        List<IVertex> Adjacent(IVertex vertex);
        // Стоимость пути между смежными вершинами
        double Cost(IVertex a, IVertex b);
    }
}