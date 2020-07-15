using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private int maxHits = 2;

    // cached references
    Level level;
    GameSession gameSession;

    // state variables
    [SerializeField] int timesHit; //TODO only serialized for debug purposes

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (CompareTag("Breakable"))
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {        
        gameSession.AddToScore();
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();        
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
