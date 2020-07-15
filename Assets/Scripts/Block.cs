using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;

    // cached reference
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);        
        Destroy(gameObject);        
        level.BlockDestroyed();
    }
}
