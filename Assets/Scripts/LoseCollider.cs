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
        // TODO - better way to tell if it is a ball
        if(collision.gameObject.name == "Ball")
        {
            level.BallDestroyed();

            Ball ball;

            // TODO - way to remove this object from the game
            collision.TryGetComponent<Ball>(out ball);

            if (ball != null)
            {
                ball.DestroyBall();                
            }
        }
        
        
    }
}
