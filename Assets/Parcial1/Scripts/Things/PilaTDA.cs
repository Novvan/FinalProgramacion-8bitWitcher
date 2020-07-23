using System;
using UnityEngine;

namespace Things
{
    public interface PilaTDA
    {
        void InicializarPila();

        // siempre que la pila este inicializada
        void Apilar(string x);

        // siempre que la pila este inicializada y no este vacıa
        void Desapilar();

        // siempre que la pila este inicializada
        bool PilaVacia();

        // siempre que la pila este inicializada y no estw vacia
        string Tope();
    }
}