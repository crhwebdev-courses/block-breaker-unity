using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;

    // state variables
    [SerializeField] private int currentScore = 0;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;    
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
}
