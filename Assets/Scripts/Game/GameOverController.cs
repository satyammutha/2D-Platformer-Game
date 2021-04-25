using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private ParticleController bombBlast;
    private ScoreController scoreController;
    private int finalScoreText;
    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
        buttonRestart.onClick.AddListener(ReloadLevel);
        finalScoreText = scoreController.score;
    }

    private void Start()
    {
        finalScore.text = "Final Score :" + finalScoreText;
    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerDeath);
        bombBlast.PlayEffect();
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
