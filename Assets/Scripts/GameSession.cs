using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] private float gameSpeed = 1f;

    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            UpdateScoreText();
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        UpdateScoreText();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    protected void UpdateScoreText()
    {
        textMeshProUGUI.text = "Score: " + currentScore;
    }
}
