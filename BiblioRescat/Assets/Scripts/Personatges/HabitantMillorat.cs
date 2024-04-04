using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitantMillorat : MonoBehaviour
{
    [Header("Moviment")]
    public float velocitat = 0.1f;
    public Transform [] puntsRecorregut;
    public GestorAnimacionsPersonatge gestorAnimacionsPersonatge;

    [Header("Missatge")]
    public GameObject prefabMissatge;
    private GameObject missatge;
    public string textMissatge;
    public float margeVerticalMissatge = 2f;
    public float margeHoritzontalMissatge = 0f;
    

    private bool aturat = false; // ----------------------------------------------------------------------------------------------- AFEGIT
    private int puntActual = 0; // ------------------------------------------------------------------------------------------------ AFEGIT

    void Start()
    {
        StartCoroutine(PassejarHabitant()); // Comença a MOURE l'habitant
        CrearMissatge(); // Crea un MISSATGE per a l'habitant
    }

    private IEnumerator PassejarHabitant()
    {
        while (true) {
            // PRIMER ES FA EL RECORREGUT
            for (int i = puntActual; i < puntsRecorregut.Length; i++) { // ------------------------------------------------------ MODIFICAT
                puntActual = i; // ------------------------------------------------------------------------------------------------ AFEGIT
                while (transform.position != puntsRecorregut[i].position) { // 2. Mentre l'habitant no ha arribat al punt
                    if (aturat) yield break; // ----------------------------------------------------------------------------------- AFEGIT
                    MoureHabitant(puntsRecorregut[i]); // 3. Es mou l'habitant cap al punt
                    AnimarHabitant(puntsRecorregut[i]);
                    yield return null; // 4. S'espera al següent fotograma
                } // 5. Es torna al punt 2 fins que l'habitant arriba al punt
            } // 6. Es torna al punt 1 fins que s'han recorregut tots els punts

            // DESPRÉS ES FA EL RECORREGUT DE TORNADA, AL REVÉS
            for (int i = puntsRecorregut.Length-1; i > 0; i--) { // 1. Es busca l'últim punt del recorregut
                puntActual = i; // ----------------------------------------------------------------------------------------------- AFEGIT
                while (transform.position != puntsRecorregut[i].position) { // 2. Mentre l'habitant no ha arribat al punt
                    if (aturat) yield break; // ---------------------------------------------------------------------------------- AFEGIT
                    MoureHabitant(puntsRecorregut[i]); // 3. Es mou l'habitant cap al punt
                    AnimarHabitant(puntsRecorregut[i]);
                    yield return null; // 4. S'espera al següent fotograma
                } // 5. Es torna al punt 2 fins que l'habitant arriba al punt
            } // 6. Es torna al punt 1 fins que s'han recorregut tots els punts
        }
    }

    private void MoureHabitant(Transform puntRecorregut)
    {
        // Es mou l'habitant cap al punt, amb la velocitat indicada
        transform.position = Vector3.MoveTowards(transform.position, puntRecorregut.position, velocitat);
    }

    private void AnimarHabitant(Transform puntRecorregut)
    {
        Vector3 moviment = puntRecorregut.position - transform.position; // Es calcula la direcció del moviment
        Vector2 direccio = new Vector2(moviment.x, moviment.y); // Es converteix la direcció a un vector 2D, perquè el personatge és 2D i no li cal la direcció Z
        gestorAnimacionsPersonatge.ActualitzarAnimacio(direccio); // Es passa la direcció a l'animador
    }

    private void CrearMissatge()
    {
        missatge = Instantiate(prefabMissatge, transform.position, Quaternion.identity); // Es crea un missatge
        MissatgeHabitant missatgeHabitant = missatge.GetComponentInChildren<MissatgeHabitant>(); // Es busca el codi del missatge
        missatgeHabitant.InicialitzarHabitant(textMissatge, transform, margeHoritzontalMissatge, margeVerticalMissatge); // Es passa el text, el personatge de referència i els marges del missatge
        missatge.SetActive(false); // Es desactiva el missatge al principi: només es mostrarà quan el jugador estigui a prop de l'habitant
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador")) { // Si el jugador s'apropa a l'habitant
            missatge.SetActive(true); // Es mostra el missatge
            aturat = true; // ----------------------------------------------------------------------------------------------------- AFEGIT
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Jugador")) { // Si el jugador s'allunya de l'habitant
            missatge.SetActive(false); // Es deixa de mostrar el missatge
            aturat = false; // --------------------------------------------------------------------------------------------------- AFEGIT
            StartCoroutine(PassejarHabitant());
        }
    }
}