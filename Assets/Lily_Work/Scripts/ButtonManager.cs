using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void TitleScreen(){
        SceneManager.LoadScene("TitleScreen");
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
    }

    public void CreditScreen(){
        SceneManager.LoadScene("CreditScreen"); 
    }

    public void HowToPlay(){
        SceneManager.LoadScene("HowToPlay"); 
    }

    public void Quit(){
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
