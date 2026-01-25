using System.Collections;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] int musicToPlay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlayDeLayed()); 
    }

    IEnumerator PlayDeLayed()
    {
        yield return null;
        Debug.Log("Music Trigger: quiero reproducir musica" + musicToPlay);
        if(AudioManager.instance == null)
        {
            Debug.LogError("No existe audio manager en esta escena");
            yield break;
        }
    }




   

}

