using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlgoDijkstra
{
    public static int[] distance;
    public static string[] nodos;

    private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < verticesCount; ++v)
        {
            
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    public static void Dijkstra(GrafoMA grafo, int source)
    {
        int[,] graph = grafo.MAdy;
        
        int verticesCount = grafo.cantNodos;

        source = grafo.Vert2Indice(source);

        distance = new int[verticesCount];

        bool[] shortestPathTreeSet = new bool[verticesCount];

        int[] nodos1 = new int[verticesCount];
        int[] nodos2 = new int[verticesCount];

        for (int i = 0; i < verticesCount; ++i)
        {
            distance[i] = int.MaxValue;

            shortestPathTreeSet[i] = false;

            nodos1[i] = nodos2[i] = -1;
        }

        distance[source] = 0;
        nodos1[source] = nodos2[source] = grafo.Etiqs[source];

        for (int count = 0; count < verticesCount - 1; ++count)
        {
            int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                {
                    distance[v] = distance[u] + graph[u, v];
                    nodos1[v] = grafo.Etiqs[u];
                    nodos2[v] = grafo.Etiqs[v];
                }   
            }
        }

        nodos = new string[verticesCount];
        int nodOrig = grafo.Etiqs[source];
        for (int i = 0; i < verticesCount; i++)
        {
            if (nodos1[i] != -1)
            {
                List<int> l1 = new List<int>();
                l1.Add(nodos1[i]);
                l1.Add(nodos2[i]);
                while (l1[0] != nodOrig)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        if (j != source && l1[0] == nodos2[j])
                        {
                            l1.Insert(0, nodos1[j]);
                            break;
                        }
                    }
                }
                for (int j = 0; j < l1.Count; j++)
                {
                    if (j == 0)
                    {
                        nodos[i] = l1[j].ToString();
                    }
                    else
                    {
                        nodos[i] += "," + l1[j].ToString();
                    }
                }
            }
        }
    }
}