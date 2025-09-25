using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphByMatrix
    {
        private int size;
        private int[,] adjacency;
        private bool[] vector;

        public GraphByMatrix(int[,] adj)
        {

            if(adj.GetLength(0) == adj.GetLength(1))
            {
                size = adj.GetLength(0);
   
                    adjacency = adj;
                vector = new bool[size];
            }
        }
        public void Depth(int vertex)
        {
            vector[vertex] = true;
            Console.WriteLine(vertex);
            for(int j = 0; j < size; j++)
            {
                if(adjacency[vertex,j] != 0 && !vector[j])
                    Depth(j);
            }
        }
    }
}
