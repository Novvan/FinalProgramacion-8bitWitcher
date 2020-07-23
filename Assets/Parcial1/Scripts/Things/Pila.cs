using System;
using UnityEngine;

namespace Things
{
    public class Pila : PilaTDA
    {
        string[] a; // arreglo en donde se guarda la informacion
        int i; // variable entera en donde se guarda la cantidad de elementos que se tienen guardados

        public void InicializarPila()
        {
            i = 0;
        }

        public void Apilar(string key)
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

        public string Tope()
        {
            return a[i - 1];
        }

        public int Cantidad()
        {
            return a.Length;
        }
    }
}