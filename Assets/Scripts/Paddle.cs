using UnityEngine;

public class Paddle : MonoBehaviour
{

    // config params
    [SerializeField] private float screenWidthInGameUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    // Cached component references

    private Ball ball;
    private GameSession gameSession;


    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        //convert mouse position from pixels to game units
        // 1. we get the precentage of screen width
        // 2. we multiply this by the width of the screen in unity game units                
        // create a Vector2 using mouses current x position and the paddles current y position
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInGameUnits;
        }

    }
}
