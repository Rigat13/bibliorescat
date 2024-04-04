using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peraba : MonoBehaviour
{
    public GameObject peraba;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            Debug.Log("PROVA PERABA");
            peraba.SetActive(true);
        }
    }
}
