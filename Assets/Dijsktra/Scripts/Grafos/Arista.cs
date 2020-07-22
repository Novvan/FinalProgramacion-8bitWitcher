using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arista
{
    public int VerticeOrigen;
    public int VerticeDestino;
    public int peso;

    public Arista(int origen, int destino, int peso)
    {
        this.VerticeOrigen = origen;
        this.VerticeDestino = destino;
        this.peso = peso;
    }
}
