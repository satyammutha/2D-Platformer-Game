using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverController : MonoBehaviour
{
    private ScoreController scoreController;
    public Button buttonRestart;
    //public Button buttonLobby;
    public TextMeshProUGUI finalScore;
    private int finalScoreText;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        //buttonLobby.onClick.AddListener(BackToLobby);
        scoreController = FindObjectOfType<ScoreController>();
        finalScoreText = scoreController.score;
    }

    private void Start()
    {
        Debug.Log("Final Score:" + finalScoreText);
        finalScore.text = "Final Score :" + finalScoreText;
    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerDeath);
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        Debug.Log("Reloading Scene:.. ");
        SoundManager.Instance.PlayOnce(SoundsForEvents.ButtonEnterLevelClick);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
