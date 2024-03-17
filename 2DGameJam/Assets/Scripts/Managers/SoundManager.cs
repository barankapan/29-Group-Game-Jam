using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource gameAudio;

    [Header("Musics")]
    [SerializeField] AudioClip EscapeSceneMusic;
    [SerializeField] AudioClip AttackSeceneMusic;
    [SerializeField] AudioClip BossSceneMusic;

    [Header("SoundEffects")]
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip Enemy;


    private void Awake()
    {
        instance = this;
        gameAudio = GetComponent<AudioSource>();
    }

    public void changeVolume(float volume)
    {
        gameAudio.mute = false;
        gameAudio.volume = volume;
        if (volume == 0)
        {
            gameAudio.mute = true;
        }
    }

    public void MuteOnOff()
    {
        gameAudio.mute = !gameAudio.mute;
    }
}
