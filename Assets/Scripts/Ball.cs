using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] collisionSounds;
    [SerializeField] private float randomFactor = 0.2f;

    private AudioSource audioSource;
    private Rigidbody2D rigidbody;
    private bool isLocked = true;

    Vector2 paddleToBallVector;
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = rigidbody.GetComponent<AudioSource>();
    }

    void Update()
    {
        LockBallToPaddle();
        LaunchBallOnMouseClick();
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isLocked = false;
            rigidbody.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        if (isLocked)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        if (!isLocked)
        {
            AudioClip audio = collisionSounds[Random.Range(0, collisionSounds.Length)];
            audioSource.PlayOneShot(audio);
            rigidbody.velocity += velocityTweak;
        }
    }
}
