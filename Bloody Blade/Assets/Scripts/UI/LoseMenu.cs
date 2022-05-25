using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void TryAgain(){
        SceneManager.LoadScene("Game");
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
