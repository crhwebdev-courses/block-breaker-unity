using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
    }

    public void LoadStartScene()
    {
        int startSceneIndex = 0;
        SceneManager.LoadScene(startSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
