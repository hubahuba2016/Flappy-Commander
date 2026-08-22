using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public Text scoreText;
    private int highScore;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score + "\nHigh Score: " + highScore;
    }
}
