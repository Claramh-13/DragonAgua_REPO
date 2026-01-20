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
    private static AudioManager Instance;

    public static AudioManager instance
    {
        get
        {
            if (instance == null) Debug.Log("No hay GameManager!");
            return instance;
        }
    }


    private void Awake()
    {
        //Singletone que no se destruye entre escenas
        if(instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
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
