using UnityEngine;
using TMPro;
public class Comptador : MonoBehaviour
{
    public int llibres = 0;
    public TMP_Text comptadorLlibres;
    public TaulerMissio taulerMissio;
    public void AfegirLlibre()
    {
        llibres++;
        comptadorLlibres.text = llibres.ToString();
        taulerMissio.AvisarLlibreTrobat();
    }
}