using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInGameUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //convert mouse position from pixels to game units
        // 1. we get the precentage of screen width
        // 2. we multiply this by the width of the screen in unity game units        
        float mousePosInGameUnits = Input.mousePosition.x / Screen.width * screenWidthInGameUnits;
        // create a Vector2 using mouses current x position and the paddles current y position
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInGameUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
