using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [Header("Configuración de Audio (Wwise)")]
    public string cancionCreditos = "Play_Nirvana";

    [Header("Configuración de Movimiento (Scroll)")]
    public RectTransform textoCreditos; 
    public float velocidadScroll = 50f; 

    void Start()
    {
        
        AkSoundEngine.PostEvent(cancionCreditos, gameObject);
    }

    void Update()
    {
        
        if (textoCreditos != null)
        {
            textoCreditos.anchoredPosition += Vector2.up * velocidadScroll * Time.deltaTime;
        }
    }

    
    public void VolverAlMenu()
    {
        AkSoundEngine.StopAll();
        SceneManager.LoadScene("Menu");
    }
}