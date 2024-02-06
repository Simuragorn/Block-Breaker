using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    private Camera mainCamera;
    private GameStatus gameStatus;
    private Level level;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.BreakableBlockCreated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, mainCamera.transform.position, 0.5f);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
