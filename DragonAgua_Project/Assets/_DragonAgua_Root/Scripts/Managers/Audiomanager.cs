using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source references")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip Arrays")]
    public AudioClip[] musicList;
    public AudioClip[] sfxList;

    //Declaración de Singleton
    private static AudioManager _instance;
    public static AudioManager instance => _instance;
  

     void Awake()
     {
        //Singletone que no se destruye entre escenas
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)

        {
            //Si hay game manager, el duplicado se destruye
            Destroy(gameObject);
        }

     } 
    
    //Fin del Sigleton
    public void PlayMusic(int musicIndex)
    {
        Debug.Log("Audiomanager: cambia musica + music index");

        if (musicSource.clip == musicList[musicIndex])
        {
            Debug.Log("Audiomanager ya estaba sonando el clip");
            return;
        }
           

        musicSource.Stop();
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();

        Debug.Log("Audiomanager:nuevo clip =" + musicSource.clip.name);
    }

    public void PlaySFX(int sfxIndex)
    {
        sfxSource.PlayOneShot(sfxList[sfxIndex]);
    }

    public void StopMusic()
    {
        musicSource.Stop();

    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }
}
