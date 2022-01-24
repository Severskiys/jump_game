using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelSwitch : MonoBehaviour
{
    public void LoadNextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(0);
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }
}
