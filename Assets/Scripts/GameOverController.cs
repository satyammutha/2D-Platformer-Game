using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour
{
    private ScoreController scoreController;
    public Button buttonRestart;
    public TextMeshProUGUI finalScore;
    private int finalScoreText;
    private void Awake()
    {
        //finalScore = GetComponent<TextMeshProUGUI>();
        buttonRestart.onClick.AddListener(ReloadLevel);
        scoreController = FindObjectOfType<ScoreController>();
        finalScoreText = scoreController.score;
    }

    private void Start()
    {
        Debug.Log("Final Score:"+finalScoreText);
        finalScore.text = "Final Score :" + finalScoreText;
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        Debug.Log("Reloading Scene:.. ");
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
