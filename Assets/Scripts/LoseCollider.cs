using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    // cached 
    private Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {                                                        
        if (collision.TryGetComponent<Ball>(out Ball ball))
        {
            level.BallDestroyed();
            ball.DestroyBall();                
        }                        
    }
}
