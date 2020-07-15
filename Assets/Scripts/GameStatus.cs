using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // config params
    [SerializeField] private TextMeshProUGUI scoreText;
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;

    // state variables
    [SerializeField] private int currentScore = 0;


    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;    
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
