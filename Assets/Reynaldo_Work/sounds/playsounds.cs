using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsManager : MonoBehaviour
{
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