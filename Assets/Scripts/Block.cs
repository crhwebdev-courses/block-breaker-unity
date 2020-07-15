using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;    
    [SerializeField] private Sprite[] hitSprites;


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
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        } else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites.Length < spriteIndex + 1)
        {
            Debug.LogError(gameObject.name + ": Block sprite is missing from array.");            
        } 
        else
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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
