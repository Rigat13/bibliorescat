using UnityEngine;

public class Llibre : ObjecteInteractiu
{
    Comptador comptador;
    void Start()
    {
        comptador = GameObject.FindWithTag("Comptador").GetComponent<Comptador>();
    }

    public override void Recollir()
    {
        comptador.AfegirLlibre(); // Els llibres es recullen d'aquesta manera, sumant al comptador de llibres
        Destroy(gameObject);
    }
}