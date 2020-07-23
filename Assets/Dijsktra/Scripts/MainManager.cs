using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private GrafoMA grafoEst;
    public int[] aristas_origen;
    public int[] aristas_destino;
    public int[] aristas_pesos;

    public List<int> caminoSeleccionado = new List<int>();
    public bool calculandoCamino;
    public Text textoResultado;
    public GameObject prifabSelector;
    public Transform parentSelector;
    public List<GameObject> selectores = new List<GameObject>();
    public InputField inputOrigen, inputDestino;
    public List<GameObject> checkpoints = new List<GameObject>();

    public void Start()
    {
        //Debug.Log("Programa Iniciado\n");

        grafoEst = new GrafoMA();

        grafoEst.InicializarGrafo();

        int [] vertices = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        for (int i = 0; i < vertices.Length; i++)
        {
            grafoEst.AgregarVertice(vertices[i]);
        }

        List<Arista> aristas = new List<Arista>{
            new Arista (1, 2, 8),
            new Arista (1, 3, 2),
            new Arista (2, 4, 4),
            new Arista (2, 5, 9),
            new Arista (3, 4, 3),
            new Arista (3, 6, 5),
            new Arista (4, 8, 3),
            new Arista (5, 10, 7),
            new Arista (6, 7, 1),
            new Arista (6, 8, 2),
            new Arista (7, 9, 9),
            new Arista (7, 11, 15),
            new Arista (8, 9, 6),
            new Arista (9, 11, 11),
            new Arista (10, 9, 1),
            new Arista (10, 12, 8),
            new Arista (11, 12, 4)
        };

        aristas_origen = new int[aristas.Count];
        aristas_destino = new int[aristas.Count];
        aristas_pesos = new int[aristas.Count];

        for(int i=0; i<aristas.Count; i++)
        {
            aristas_origen[i] = aristas[i].VerticeOrigen;
            aristas_destino[i] = aristas[i].VerticeDestino;
            aristas_pesos[i] = aristas[i].peso;
        }

        //Debug.Log("\nAgregando las aristas");
        for (int i = 0; i < aristas_pesos.Length; i++)
        {
            grafoEst.AgregarArista(aristas_origen[i], aristas_destino[i], aristas_pesos[i]);
        }

    }

    public void AccionResetSelecciones()
    {
        ResetSeleccion();
        calculandoCamino = false;
    }

    public void AccionCalcularCamino()
    {
        var origen = int.Parse(inputOrigen.text);
        var destino = int.Parse(inputDestino.text);

        ResetSeleccion();

        AlgoDijkstra.Dijkstra(grafoEst, origen);

        var distancia = string.Empty;
        var nodos = string.Empty;

        for (int i = 0; i < grafoEst.cantNodos; ++i)
        {
            if (AlgoDijkstra.distance[i] == int.MaxValue)
            {
                distancia = "---";
            }
            else
            {
                distancia = AlgoDijkstra.distance[i].ToString();
            }

            if(grafoEst.Etiqs[i] == destino)
            {
                nodos = AlgoDijkstra.nodos[i];
                var mensaje = string.Format("Vertice: {0} --x-- Distancia: {1} --x-- Camino: {2}", grafoEst.Etiqs[i], distancia, AlgoDijkstra.nodos[i]);
                textoResultado.text = mensaje;
                Debug.Log(mensaje);
            }
        }

        try
        {
            var indiceCheckpoints = nodos.Split(',');
            foreach(string indice in indiceCheckpoints)
            {
                var checkpoint = checkpoints[int.Parse(indice)-1];
                AccionSpawnSelector(checkpoint);
            }
        }
        catch
        {
            textoResultado.text += "\n No se encontro un camino";
        }     
    }

    public void AccionSpawnSelector(GameObject vertice)
    {
        var selector = Instantiate(prifabSelector, parentSelector);
        selector.transform.localPosition = vertice.transform.localPosition + new Vector3(76, -97, 1);
        selectores.Add(selector);
    }

    public void LimpiarSelectores()
    {
        foreach(var selector in selectores)
        {
            Destroy(selector);
        }
        selectores.Clear();
    }

    public void ResetSeleccion()
    {
        caminoSeleccionado.Clear();
        LimpiarSelectores();
        textoResultado.text = "0";
        inputOrigen.text = string.Empty;
        inputDestino.text = string.Empty;
    }
}
