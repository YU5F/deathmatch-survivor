using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEvents : MonoBehaviour
{
    public void BackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
