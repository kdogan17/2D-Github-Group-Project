using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool EndGame = false;

    public void WinGame()
    {
        if (EndGame == false) return;

        EndGame = true;
        SceneManager.LoadScene("Win_UI");
    }

    public void LoseGame()
    {
        if (EndGame == false) return;

        EndGame = true;
        SceneManager.LoadScene("Lose_UI");
    }
}