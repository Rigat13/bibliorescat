using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ControladorJugador : MonoBehaviour
{
    public float velocitat = 5f; // Velocitat de moviment del personatge de la jugadora o jugador
    private Rigidbody2D cosRigidJugador; // Component que fa que el personatge no travessi les parets
    public GestorAnimacionsPersonatge animacionsPersonatge; // Classe que creem perquè s'encarregui de canviar les animacions d'un personatge, en aquest cas del jugador o jugadora
    void Start() // Mètode que s'executa al principi de tot. Aquí busquem els components que toca, que són de la nostra jugadora o jugador
    {
        cosRigidJugador = GetComponent<Rigidbody2D>();
    }

    void Update() // Mètode que s'executa a cada frame (molts cops per segon)
    {
        float movimentHoritzontal = Input.GetAxis("Horizontal"); // Es detecta si es prémen les tecles a l'esquerra (← o A) o a la dreta (→ o D)
        float movimentVertical = Input.GetAxis("Vertical"); // Es detecta si es prémen les tecles amunt (↑ o W) o avall (↓ o S)

        Vector2 moviment = new Vector2(movimentHoritzontal, movimentVertical); // S'ajunta el moviment horitzontal i el vertical en un vector
        cosRigidJugador.velocity = moviment * velocitat; // Es mou el personatge en la direcció, magnitud la velocitat que toqui

        animacionsPersonatge.ActualitzarAnimacio(moviment);
    }

}
