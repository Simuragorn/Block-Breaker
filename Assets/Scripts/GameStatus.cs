using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] private float gameSpeed = 1f;

    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        textMeshProUGUI.text = "Score: " + currentScore;
    }
}
