using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite[] damagedSprites;
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;

    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;
    private GameSession gameStatus;
    private Level level;

    [SerializeField] private int timesHit = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = FindObjectOfType<Camera>();
        gameStatus = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        if (gameObject.CompareTag("Breakable"))
        {
            level.BreakableBlockCreated();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = damagedSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (spriteIndex < damagedSprites.Length)
        {
            spriteRenderer.sprite = damagedSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }

    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, mainCamera.transform.position, 0.5f);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparklesEffect = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparklesEffect, 1f);
    }
}
