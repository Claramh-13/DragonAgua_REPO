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
        AudioManager.instance.PlayMusic(musicToPlay);
       
    }




   

}

