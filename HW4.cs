using System;

namespace HW4
{
    class Program
    {

        public static void Main()
        {
            int nCity = int.Parse(Console.ReadLine());


            string[] dCity = new string[nCity];

            for (int i = 0; i < dCity.Length; i++)
            {
                dCity[i] = Console.ReadLine();
            }

            int[,] graph = new int[nCity, nCity];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        graph[i, j] = 0;
                    }
                    else if (j == i)
                    {
                        graph[i, j] = -1;
                    }
                    else
                    {
                        graph[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    graph[i, j] = graph[j, i];

                }
            }
            string distance = Console.ReadLine();
            int ndistance = 0;
            for (int i = 0; i < dCity.Length; i++)
            {
                if (dCity[i] == distance)
                {
                    ndistance = i;
                }
            }
            City city = new City();
            city.destination(graph, ndistance, nCity);
        }
    }
    class City
    {

        int lessDistance(int[] distance, bool[] Set, int v)
        {

            int less = int.MaxValue, less_index = -1;

            for (int y = 0; y < v; y++)
                if (Set[y] == false && distance[y] <= less)
                {
                    less = distance[y];
                    less_index = y;
                }

            return less_index;
        }


        void Conclusion(int[] distance)
        {
            Console.WriteLine(distance[0]);
        }


        public void destination(int[,] graph, int src, int v)
        {
            int[] distance = new int[v];


            bool[] Set = new bool[v];


            for (int i = 0; i < v; i++)
            {
                distance[i] = int.MaxValue;
                Set[i] = false;
            }


            distance[src] = 0;


            for (int count = 0; count < v - 1; count++)
            {

                int x = lessDistance(distance, Set, v);


                Set[x] = true;

                for (int y = 0; y < v; y++)


                    if (!Set[y] && graph[x, y] != -1 &&
                         distance[x] != int.MaxValue && distance[x] + graph[x, y] < distance[y])
                        distance[y] = distance[x] + graph[x, y];
            }


            Conclusion(distance);
        }
    }
}
