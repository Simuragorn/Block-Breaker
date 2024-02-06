using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    private Camera mainCamera;
    private GameSession gameStatus;
    private Level level;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        gameStatus = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        level.BreakableBlockCreated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
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
