using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float yPosition = 0.5f;
    void Update()
    {
        float mouseXPositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 padlePosition = new Vector2(mouseXPositionInUnits, yPosition);
        padlePosition.x = Mathf.Clamp(padlePosition.x, minX, maxX);
        transform.position = new Vector2(padlePosition.x, transform.position.y);
    }
}
