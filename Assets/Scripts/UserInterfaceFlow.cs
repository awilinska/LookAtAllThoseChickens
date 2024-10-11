using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfaceFlow : MonoBehaviour
{
    int currentScene;
    public void ReturnToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void NewGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void PauseGame () {
        Time.timeScale = 0;
    }
    
    public void ResumeGame () {
        Time.timeScale = 1;
    }

    public void Quit () {
        Application.Quit();
    }

    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
