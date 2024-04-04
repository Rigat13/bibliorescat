using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(IniciCarregaEscena))]
public class TaulerMissio : MonoBehaviour
{
    [Header("Objectiu")]
    public int objectiuLlibres = 3;
    public Comptador comptador;

    [Header("Panells")]
    public GameObject alerta;
    public Animation panellMissioEnCurs;
    public Animation panellMissioComplerta; 
    public TMP_Text comptadorLlibresPanellEnCurs, comptadorLlibresPanellComplerta;

    void Start()
    {
        alerta.SetActive(false); // S'oculta el senyal d'alerta
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Jugador")) {
            if (comptador.llibres >= objectiuLlibres) {
                ObrirPanellMissioComplerta();
            } else {
                ObrirPanellMissioEnCurs();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Jugador")) {
            if (comptador.llibres >= objectiuLlibres) {
                TancarPanellMissioComplerta();
            } else {
                TancarPanellMissioEnCurs();
            }
        }
    }

    public void AvisarLlibreTrobat() {
        if (comptador.llibres >= objectiuLlibres) {
            alerta.SetActive(true); // S'activa el senyal d'alerta
        }
    }

    public void ObrirPanellMissioEnCurs() {
        comptadorLlibresPanellEnCurs.text = comptador.llibres + " / " + objectiuLlibres;
        panellMissioEnCurs.gameObject.SetActive(true);
        panellMissioEnCurs.Play("ObrirPanell");
    }

    public void TancarPanellMissioEnCurs() {
        panellMissioEnCurs.gameObject.SetActive(false);
        panellMissioEnCurs.Play("TancarPanell");
    }

    public void ObrirPanellMissioComplerta() {
        comptadorLlibresPanellComplerta.text = comptador.llibres + " / " + objectiuLlibres;
        panellMissioComplerta.gameObject.SetActive(true);
        panellMissioComplerta.Play("ObrirPanell");
    }

    public void TancarPanellMissioComplerta() {
        panellMissioComplerta.gameObject.SetActive(false);
        panellMissioComplerta.Play("TancarPanell");
    }

    public void ConfirmarViatge() {
        TancarPanellMissioComplerta();
        GetComponent<IniciCarregaEscena>().CarregarProperaEscena();
    }
}
