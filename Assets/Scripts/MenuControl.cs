using UnityEngine;

public class MenuControl : MonoBehaviour
{
    int completed;
    public GameObject MainMenu;
    public GameObject Tutorial;

    void Update() {
        completed = PlayerPrefs.GetInt("Tutorial", 0);
    }

    public void StartGame() {
        if (completed == 0) {
            MainMenu.SetActive(false);
            Tutorial.SetActive(true);
        }
        else {
            MainMenu.SetActive(false);
        }
    }

    public void TutorialCompleted() {
        PlayerPrefs.SetInt("Tutorial", 1);
    }
}
