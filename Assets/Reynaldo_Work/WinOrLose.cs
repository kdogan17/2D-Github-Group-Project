using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool EndGame = false;

    public void WinGame()
    {
        if (EndGame) return;

        EndGame = true;
        SceneManager.LoadScene("Win_UI");
    }

    public void LoseGame()
    {
        if (EndGame) return;

        EndGame = true;
        SceneManager.LoadScene("Lose_UI");
    }
}