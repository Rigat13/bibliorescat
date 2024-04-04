using UnityEngine;

public class Llibre : ObjecteInteractiu
{
    Comptador comptador;
    public AudioSource so;
    void Start()
    {
        comptador = GameObject.FindWithTag("Comptador").GetComponent<Comptador>();
    }

    public override void Recollir()
    {
        comptador.AfegirLlibre(); // Els llibres es recullen d'aquesta manera, sumant al comptador de llibres
        so.Play(); // Es reprodueix un so
        Destroy(gameObject); // Es destrueix l'objecte
    }
}