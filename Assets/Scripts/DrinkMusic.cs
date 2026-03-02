using UnityEngine;

public class DrinkMusic : MonoBehaviour
{
    [Header("Configuración de Wwise")]
    [Tooltip("Escribe aquí el nombre del evento (ej: Play_Juggernog)")]
    public string drinkSongEvent;

    private uint songPlayingID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            songPlayingID = AkSoundEngine.PostEvent(drinkSongEvent, gameObject);
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            AkSoundEngine.StopPlayingID(songPlayingID);
        }
    }
}