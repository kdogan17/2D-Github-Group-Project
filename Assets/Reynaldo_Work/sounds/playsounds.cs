using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsManager : MonoBehaviour
{
    public AudioSource musicSource; //background & theme music
    public AudioSource SfxSource; //sound effects

    void Start()
    {
        PlaySceneMusic(SceneManager.GetActiveScene().name);

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name);
    }

    public void PlaySong(string songName)
    {
       AudioClip sounds = Resources.Load<AudioClip>(songName);
       
       if (sounds != null) {
        musicSource.clip = sounds;
        musicSource.Play();
        }
        else
        {
        Debug.Log("Sound not found: " + songName);
        }
    }

     public void PlaySound(string soundName)
    {
        AudioClip sounds = Resources.Load<AudioClip>(soundName);

        if (sounds != null)
        {
            SfxSource.PlayOneShot(sounds); //plays once so no overlap
        }
    }

    void PlaySceneMusic(string sceneName)
    {
        switch (sceneName)
        {
            case "TitleScreen":
                PlaySong("Lobby");
                break;
            case "Game":
                PlaySong("Enemy spotted");
                break;
            case "Win_UI":
                PlaySong("VICTORY");
                break;
            case "Lose_UI":
                PlaySong("theend");
                break;
            default:
                break;
        }
    }
}