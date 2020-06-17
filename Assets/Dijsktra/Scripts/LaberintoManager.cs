using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaberintoManager : MonoBehaviour
{
    private GrafoMA grafoEst;
    public int[] aristas_origen;
    public int[] aristas_destino;
    public int[] aristas_pesos;

     /* ELEMENTOS DE UNITY */
    public List<Vector3> SetAristas;    /* Utiliza la pos x para el orgien, la pos y para el distino, y la pos z para el peso */
    public Text textoResultado;
    public InputField inputOrigen, inputDestino;
    public GameObject player;   /* Representado por un cubo */
    public List<GameObject> nodosGrafo; /* Lista de nodos (gameobject) del escenario */
    public bool animarPlayer = false;   /* Indica cuando animar en el update */
    public int indexCamino = 0; /* Indice para recorrer el camino encontrado */
    public string[] camino; /* Camino encontrado por dijkstra */


    void Start()
    {
        Debug.Log("Programa Iniciado\n");

        // creo la estructura de grafos (estatica)
        grafoEst = new GrafoMA();

        // inicializo TDA
        grafoEst.InicializarGrafo();

        // vector de vértices
        int [] vertices = new int[nodosGrafo.Count];
        // agrego los vértices
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = i+1;
            grafoEst.AgregarVertice(vertices[i]);
        }

        // vector de aristas - vertices origen
        aristas_origen = new int[SetAristas.Count];
        // vector de aristas - vertices destino
        aristas_destino = new int[SetAristas.Count];
        // vector de aristas - pesos
        aristas_pesos = new int[SetAristas.Count];

        for(int i=0; i<SetAristas.Count; i++)
        {
            aristas_origen[i] = (int)SetAristas[i].x;
            aristas_destino[i] = (int)SetAristas[i].y;
            aristas_pesos[i] = (int)SetAristas[i].z;
        }

        // agrego las aristas
        Debug.Log("\nAgregando las aristas");
        for (int i = 0; i < aristas_pesos.Length; i++)
        {
            grafoEst.AgregarArista(aristas_origen[i], aristas_destino[i], aristas_pesos[i]);
        }

        Debug.Log("\nListado de Etiquetas de los nodos");
        for (int i = 0; i < grafoEst.Etiqs.Length; i++)
        {
            if (grafoEst.Etiqs[i] != 0)
            {
                Debug.Log("Nodo: " + grafoEst.Etiqs[i].ToString());
            }
        }

        Debug.Log("\nListado de Aristas (Inicio, Fin, Peso)");
        for (int i = 0; i < grafoEst.cantNodos; i++)
        {
            for (int j = 0; j < grafoEst.cantNodos; j++)
            {
                if (grafoEst.MAdy[i, j] != 0)
                {
                    // obtengo la etiqueta del nodo origen, que está en las filas (i)
                    int nodoIni = grafoEst.Etiqs[i];
                    // obtengo la etiqueta del nodo destino, que está en las columnas (j)
                    int nodoFin = grafoEst.Etiqs[j];
                    Debug.Log(nodoIni.ToString() + ", " + nodoFin.ToString() + ", " + grafoEst.MAdy[i, j].ToString());
                }
            }
        }
    }

    void Update() 
    {
        if(animarPlayer)
        {
            RecorrerCamino(camino);
        }    
    }

    public void AccionCalcularCamino()
    {
        var origen = int.Parse(inputOrigen.text);
        var destino = int.Parse(inputDestino.text);

        ResetSeleccion();

        // se llema al algoritmo dijkstra
        AlgoDijkstra.Dijkstra(grafoEst, origen);

        // obtener el camino
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

        /* Se preparan los datos para la animación de recorrido del player */
        animarPlayer = true;
        camino = nodos.Split(',');
        player.transform.position = nodosGrafo[int.Parse(camino[0])-1].transform.position;
    }

    private void ResetSeleccion()
    {
        textoResultado.text = "0";
        inputOrigen.text = string.Empty;
        inputDestino.text = string.Empty;
        indexCamino = 0;
    }

    /* Anima al player recorriendo nodo a nodo el camino encontrado */
    private void RecorrerCamino(string[] camino)
    {
        /* 2- Recorrer camino nodo a nodo */
        Debug.Log(string.Format("Indice camino: {0}, nodo de camino: {1}", indexCamino, camino[indexCamino]));
        float step = Time.deltaTime * 5;
        if(Vector3.Distance(nodosGrafo[int.Parse(camino[indexCamino])-1].transform.localPosition, player.transform.localPosition) < 0.001f)
        {
            /* Al alcanzar el nodo pasa al siguiente, de terminar el recorrido frena la animación */
            indexCamino++;
            if(indexCamino == camino.Length)
            {
                animarPlayer = false;
            }
        }
        else
        {
            /* Animación al siguiente nodo */
            player.transform.position = Vector3.MoveTowards(player.transform.localPosition, nodosGrafo[int.Parse(camino[indexCamino])-1].transform.localPosition, step);
        }
    }
}
