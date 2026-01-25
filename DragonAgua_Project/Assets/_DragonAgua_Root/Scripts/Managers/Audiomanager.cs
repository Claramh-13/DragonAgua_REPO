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
        musicSource.clip = musicList[musicIndex];
        musicSource.Play(); 
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
