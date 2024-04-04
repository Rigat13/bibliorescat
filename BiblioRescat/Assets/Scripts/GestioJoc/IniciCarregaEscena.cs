using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciCarregaEscena : MonoBehaviour
{
    [SerializeField] private IndexsEscena properaEscena;
    [SerializeField] private AudioSource audioBoto;

    public void CarregarProperaEscena()
    {
        StartCoroutine(CarregarPartidaEsperant());
    }

    private IEnumerator CarregarPartidaEsperant()
    {
        float duracio = ReproduirIObtenirDuracioAudio();
        yield return new WaitForSeconds(duracio);

        GestorJoc.instancia.IniciarCarregarPartida(properaEscena);
    }

    private float ReproduirIObtenirDuracioAudio()
    {
        float duracio = 0;
        if (audioBoto != null)
        {
            duracio = audioBoto.clip.length;
            audioBoto.PlayOneShot(audioBoto.clip);
        }
        return duracio;
    }
}
