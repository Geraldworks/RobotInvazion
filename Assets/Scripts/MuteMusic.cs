using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    /// <summary>
    /// This script provides the functionality to mute the background music
    /// </summary>

    readonly private float vol = 0.1f;

    private AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void TriggerMute()
    {
        if (music.volume != 0)
        {
            music.volume = 0;
        }
        else
        {
            music.volume = vol;
        }
    }
}
