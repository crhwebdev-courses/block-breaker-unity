using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private string endScene = "Game Over";
    [SerializeField] private int breakableBlocks; // Serialized for debugging purposes
    [SerializeField] private int balls; // Serialized for debugging purposes

    // cached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }
    
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {            
            sceneLoader.LoadNextScene();
        }
    }

    public void CountBalls()
    {
        balls++;
    }

    public void BallDestroyed()
    {
        balls--;
        if(balls <= 0)
        {
            sceneLoader.LoadNamedScene(endScene);
        }
    }

}
