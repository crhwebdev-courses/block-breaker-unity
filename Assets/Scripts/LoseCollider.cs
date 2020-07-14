using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] private string endScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(endScene);
    }
}
