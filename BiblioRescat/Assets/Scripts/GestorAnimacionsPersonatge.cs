using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class GestorAnimacionsPersonatge : MonoBehaviour
{
    private Animator animador; // Gestiona les animacions del personatge
    void Start() // Mètode que s'executa al principi de tot
    {
        animador = GetComponent<Animator>(); // Aquí busquem l'animador que té el mateix personatge que té aquest SpritesPersonatge
    }

    public void ActualitzarAnimacio(Vector2 direction)
    {
        if (direction.magnitude <= 0.01f) // Si el personatge  està quiet
        {
            animador.SetBool("quiet", true);
        }
        else // Si el personatge no està quiet
        {
            animador.SetBool("quiet", false);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calcula l'angle de moviment
            TriarAnimacio(angle);
        }
    }

    void TriarAnimacio(float angle)
    {
        if (angle < -45 && angle >= -135)
        {
            animador.SetTrigger("avall"); // ↓
        }
        else if (angle >= -45 && angle < 45)
        {
            animador.SetTrigger("dreta"); // →
        }
        else if (angle >= 45 && angle < 135)
        {
            animador.SetTrigger("amunt"); // ↑
        }
        else
        {
            animador.SetTrigger("esquerra"); // ←
        }
    }
}