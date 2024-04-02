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
        comptador.AfegirLlibre();
        Destroy(gameObject);
    }
}