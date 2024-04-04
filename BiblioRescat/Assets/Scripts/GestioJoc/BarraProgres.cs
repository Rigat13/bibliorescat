using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgres : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int minim = 0;
    [SerializeField] private int maxim = 100;
    [SerializeField] private int actual = 0;


    public void ActualitzarActual(int valor)
    {
        this.actual = valor;
        ObtenirProgresActual();
    }

    private void ObtenirProgresActual()
    {
        float margeActual = actual - minim;
        float margeMaxim = maxim - minim;
        float progres = margeActual / margeMaxim;
        slider.value = progres;
    }
}
