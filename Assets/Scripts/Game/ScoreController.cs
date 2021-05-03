using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    private TextMeshProUGUI ScoreText;

    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        ScoreText.text = "SCORE: " + score;
    }
}
