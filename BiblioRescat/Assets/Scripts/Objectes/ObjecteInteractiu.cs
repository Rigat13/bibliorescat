using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObjecteInteractiu : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Quan algú xoqui amb l'objecte
    {
        if (other.gameObject.CompareTag("Jugador")) // Si qui xoca és el/la jugador/a
        {
            Recollir();
        }
    }

    public abstract void Recollir(); // Expliquem que l'objecte s'ha de poder recollir
                                     // però cada objecte es pot recollir d'una manera diferent
}