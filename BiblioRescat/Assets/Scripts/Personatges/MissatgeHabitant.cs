using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissatgeHabitant : MonoBehaviour
{
    private bool inicialitzat = false;
    private Transform posicioHabitant;
    private float margeHoritzontal;
    private float margeVertical;

    public void InicialitzarHabitant(string textMissatge, Transform posicioHabitant, float margeHoritzontal, float margeVertical)
    {
        GetComponentInChildren<TMP_Text>().text = textMissatge;
        this.posicioHabitant = posicioHabitant;
        this.margeHoritzontal = margeHoritzontal;
        this.margeVertical = margeVertical;
        inicialitzat = true;
    }

    void Update() // Es crida un cop per cada fotograma
    {
        if (inicialitzat)
        {
            // Agafa la posició de l'habitant en el món 2D i la converteix a la posició de la pantalla on va el missatge.
            Vector2 posicioDesitjada = new Vector2(posicioHabitant.position.x + margeHoritzontal, posicioHabitant.position.y + margeVertical);
            Vector3 posicioDesitjadaPantalla = Camera.main.WorldToScreenPoint(posicioDesitjada);
            transform.position = posicioDesitjadaPantalla;
        }
    }
}
