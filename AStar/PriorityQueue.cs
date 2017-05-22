using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
    public class PriorityQueue
    {
        private List<Tuple<List<IVertex>, double>> queue;

        public PriorityQueue()
        {
            queue = new List<Tuple<List<IVertex>, double>>();
        }

        public void Add(double cost, List<IVertex> elem)
        {
            int i;
            for (i = 0; i < queue.Count && cost > queue[i].Item2; i++) ;
            queue.Insert(i, new Tuple<List<IVertex>, double>(elem, cost));
        }

        public List<IVertex> First()
        {
            return queue[0].Item1;
        }

        public void RemoveFirst()
        {
            queue.RemoveAt(0);
        }

        public int Count
        {
            get
            {
                return queue.Count;
            }
        }
    }
}