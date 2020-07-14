using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] private string endScene = "Game Over";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(endScene);
    }
}
