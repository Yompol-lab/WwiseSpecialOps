using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Configuración de Audio (Wwise)")]
    public string cancionMenu = "Play_SnakeEater"; 
    private uint musicID;

    void Start()
    {
        
        musicID = AkSoundEngine.PostEvent(cancionMenu, gameObject);
    }

    public void Jugar()
    {
        
        AkSoundEngine.StopPlayingID(musicID);
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public void VolverJugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Credits()
    {
        
        AkSoundEngine.StopPlayingID(musicID);
        SceneManager.LoadScene("Credits");
    }
}