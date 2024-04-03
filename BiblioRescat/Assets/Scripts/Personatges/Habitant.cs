using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitant : MonoBehaviour
{
    public float velocitat = 0.1f;
    public Transform [] puntsRecorregut;
    public GestorAnimacionsPersonatge gestorAnimacionsPersonatge;

    private int puntActual = 0;

    void Start()
    {
        StartCoroutine(PassejarHabitant());
    }

    private IEnumerator PassejarHabitant()
    {
        while (true) {
            // PRIMER ES FA EL RECORREGUT
            for (int i = 0; i < puntsRecorregut.Length; i++) { // 1. Es busca el primer punt del recorregut
                while (transform.position != puntsRecorregut[i].position) { // 2. Mentre l'habitant no ha arribat al punt
                    MoureHabitant(puntsRecorregut[i]); // 3. Es mou l'habitant cap al punt
                    AnimarHabitant(puntsRecorregut[i]);
                    yield return new WaitForSeconds(velocitat); // 4. S'espera un temps
                } // 5. Es torna al punt 2 fins que l'habitant arriba al punt
            } // 6. Es torna al punt 1 fins que s'han recorregut tots els punts

            // DESPRÉS ES FA EL RECORREGUT DE TORNADA, AL REVÉS
            for (int i = puntsRecorregut.Length-1; i > 0; i--) { // 1. Es busca l'últim punt del recorregut
                 while (transform.position != puntsRecorregut[i].position) { // 2. Mentre l'habitant no ha arribat al punt
                      MoureHabitant(puntsRecorregut[i]); // 3. Es mou l'habitant cap al punt
                      yield return new WaitForSeconds(velocitat); // 4. S'espera un temps
                 } // 5. Es torna al punt 2 fins que l'habitant arriba al punt
            } // 6. Es torna al punt 1 fins que s'han recorregut tots els punts
        }
    }

    private void MoureHabitant(Transform puntRecorregut)
    {
        transform.position = Vector3.MoveTowards(transform.position, puntRecorregut.position, velocitat);
    }

    private void AnimarHabitant(Transform puntRecorregut)
    {
        Vector3 moviment = puntRecorregut.position - transform.position;
        Vector2 direccio = new Vector2(moviment.x, moviment.y);
        gestorAnimacionsPersonatge.ActualitzarAnimacio(direccio);
    }
}