using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public int musicIndex;

    private void Start()
    {
        AudioManager.instance.PlayMusic(musicIndex);
    }
}
