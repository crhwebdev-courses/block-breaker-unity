using UnityEngine;

public class Ball : MonoBehaviour
{   // config params
    [SerializeField] private Paddle paddle1;

    // state
    private Vector2 paddleToBallVector;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
