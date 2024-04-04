using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GestorJoc : MonoBehaviour
{
    public static GestorJoc instancia;
    public static IndexsEscena escenaActual;
    [SerializeField] private GameObject pantallaCarrega;
    [SerializeField] private BarraProgres barra;
    private List<AsyncOperation> escenesCarregant = new List<AsyncOperation>();
    public float duracioFalsaCarrega = 1f;
    private int numeroNivellActual = 0;

    private void Awake()
    {
        instancia = this;
        escenaActual = IndexsEscena.MENU_INICIAL;
        SceneManager.LoadSceneAsync((int)IndexsEscena.MENU_INICIAL, LoadSceneMode.Additive);
    }

    public void IniciarCarregarPartida(IndexsEscena properaEscena)
    {
        numeroNivellActual++;
        pantallaCarrega.gameObject.SetActive(true);
        CarregarPartida(properaEscena);
        StartCoroutine(FALSEJAT_ObtenirProgresCarregaEscenaIActivarEscena(properaEscena));
    }

    private void CarregarPartida(IndexsEscena properaEscena)
    {
        escenesCarregant.Add(SceneManager.UnloadSceneAsync((int)escenaActual));
        escenesCarregant.Add(SceneManager.LoadSceneAsync((int)properaEscena, LoadSceneMode.Additive));
        escenaActual = properaEscena;
    }

    private IEnumerator ObtenirProgresCarregaEscenaIActivarEscena()
    {
        for (int i = 0; i < escenesCarregant.Count; i++)
        {
            while (!escenesCarregant[i].isDone)
            {
                ActualitzarProgres();
                yield return null;
            }
        }

        pantallaCarrega.gameObject.SetActive(false);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(((int)escenaActual)));
        ModificarNumeroNivell();
    }

    private void ActualitzarProgres()
    {
        float progresEscena = 0;
        foreach (AsyncOperation operacio in escenesCarregant)
        {
            progresEscena += operacio.progress;
        }
        progresEscena = (progresEscena / escenesCarregant.Count) * 100f;
        barra.ActualitzarActual(Mathf.RoundToInt(progresEscena));
    }

    private IEnumerator FALSEJAT_ObtenirProgresCarregaEscenaIActivarEscena(IndexsEscena properaEscena)
    { 
        float progresFalsEscena = 0f;
        float temps = 0f;
        while (temps < duracioFalsaCarrega)
        {
            temps += Time.deltaTime;
            progresFalsEscena = (temps / duracioFalsaCarrega) * 100f;
            barra.ActualitzarActual(Mathf.RoundToInt(progresFalsEscena));
            yield return Time.deltaTime;
        }
        for (int i = 0; i < escenesCarregant.Count; i++)
        {
            while (!escenesCarregant[i].isDone)
            {
                yield return null;
            }
        }
        pantallaCarrega.gameObject.SetActive(false);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(((int)escenaActual)));
        ModificarNumeroNivell();
    }

    private void ModificarNumeroNivell()
    {
        // Busca el GameObject amb l'etiqueta "TextNivell" a l'escena que ha carregat i modifica el text amb el número de nivell actual
        GameObject textNivell = GameObject.FindGameObjectWithTag("TextNivell");
        if (textNivell != null)
        {
            textNivell.GetComponent<TMP_Text>().text = numeroNivellActual + "|";
        }
    }
}
