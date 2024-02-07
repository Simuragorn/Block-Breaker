using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float yPosition = 0.5f;

    private Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
    void Update()
    {
        float padleXPosition = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = new Vector2(padleXPosition, transform.position.y);
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameSession>().IsAutoPlayEnabled)
        {
            return ball.transform.position.x;
        }
        else
        {
            float mouseXPositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            Vector2 padlePosition = new Vector2(mouseXPositionInUnits, yPosition);
            return padlePosition.x;
        }
    }
}
