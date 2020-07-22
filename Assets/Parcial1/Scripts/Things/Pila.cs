using System;
using UnityEngine;

namespace Things
{
    public class Pila : MonoBehaviour, PilaTDA
    {
        String[] a; // arreglo en donde se guarda la informacion
        int i; // variable entera en donde se guarda la cantidad de elementos que se tienen guardados

        public void InicializarPila()
        {
            i = 0;
        }

        public void Apilar(String key)
        {
            i++;
            a[i] = key;
        }

        public void Desapilar()
        {
            i--;
        }

        public bool PilaVacia()
        {
            return (i == 0);
        }

        public String Tope()
        {
            return a[i - 1];
        }

        public int Cantidad()
        {
            return a.Length;
        }
    }
}