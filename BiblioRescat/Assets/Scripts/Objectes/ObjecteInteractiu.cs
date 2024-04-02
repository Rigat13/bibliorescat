using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObjecteInteractiu : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            Recollir();
        }
    }

    public abstract void Recollir();
}