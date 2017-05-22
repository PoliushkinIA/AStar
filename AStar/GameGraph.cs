using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
    public class GameGraph : IGraph
    {
        private uint dimension;

        public GameGraph(uint dimension)
        {
            if (dimension <= 1)
                throw new ArgumentException();
            this.dimension = dimension;
        }

        public List<IVertex> Adjacent(IVertex vertex)
        {
            List<IVertex> result = new List<IVertex>();
            uint[,] state = ((GameVertex)vertex).State;
            // Найдем пустую клеточку (ноль)
            int i, j = 0;
            for (i = 0; i < dimension; i++)
            {
                for (j = 0; j < dimension; j++)
                    if (state[i, j] == 0) break;
                if (j != dimension && state[i, j] == 0) break;
            }
            // Сформируем список возможных состояний, в которые можно перейти, передвинув фишку на свободное место
            GameVertex newVertex;
            uint[,] newState;
            if (i != 0) 
            {
                newState = (uint[,])state.Clone();
                newState[i, j] = newState[i - 1, j];
                newState[i - 1, j] = 0;
                newVertex = new GameVertex(dimension, newState);
                result.Add(newVertex);
            }
            if (j != 0)
            {
                newState = (uint[,])state.Clone();
                newState[i, j] = newState[i, j - 1];
                newState[i, j - 1] = 0;
                newVertex = new GameVertex(dimension, newState);
                result.Add(newVertex);
            }
            if (i != dimension - 1)
            {
                newState = (uint[,])state.Clone();
                newState[i, j] = newState[i + 1, j];
                newState[i + 1, j] = 0;
                newVertex = new GameVertex(dimension, newState);
                result.Add(newVertex);
            }
            if (j != dimension - 1)
            {
                newState = (uint[,])state.Clone();
                newState[i, j] = newState[i, j + 1];
                newState[i, j + 1] = 0;
                newVertex = new GameVertex(dimension, newState);
                result.Add(newVertex);
            }
            return result;
        }

        public double Cost(IVertex a, IVertex b)
        {
            // Вершины должны быть смежными!!
            if (!Adjacent(a).Contains(b))
                throw new ArgumentException("Vertices must be adjacent!");
            // Стоимость передвижения фишки всегда равна 1
            return 1;
        }
    }
}