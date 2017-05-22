using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
    public class GameVertex : IVertex
    {
        private uint dimension;
        private uint[,] state;

        public GameVertex(uint dimension, uint[,] state)
        {
            // Состояние игры - квадратное поле, в котором по одному разу встречаются все числа от нуля до длины стороны в квадрате
            if (dimension != state.GetLength(0) && dimension != state.GetLength(1))
                throw new ArgumentException();

            for (uint i = 0; i < dimension * dimension; i++)
                if (state.Cast<uint>().Count(p => p == i) != 1)
                    throw new ArgumentException();

            this.dimension = dimension;
            this.state = state;
        }

        public uint Dimension
        {
            get
            {
                return dimension;
            }
        }

        public uint[,] State
        {
            get
            {
                return (uint[,])state.Clone();
            }

        }

        public double HFunction()
        {
            double res = 0;
            // Эвристическая оценка расстояния вершины от целевой - "Манхэттенское расстояние" между положением каждой фишки в текущем и целевом состояниях
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    res += Math.Abs(state[i, j] / dimension - i) + Math.Abs(state[i, j] % dimension - j);
            return res;
        }

        public override bool Equals(object vertex)
        {
            if (dimension != ((GameVertex)vertex).dimension)
                return false;
            uint[,] state1 = ((GameVertex)vertex).state;
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    if (state[i, j] != state1[i, j])
                        return false;
            return true;
        }
    }
}