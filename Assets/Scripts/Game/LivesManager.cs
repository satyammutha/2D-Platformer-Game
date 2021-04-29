using UnityEngine;
using TMPro;
public class LivesManager : MonoBehaviour
{
    [SerializeField] private int defaultLives;
    [SerializeField] private int livesCounter;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI lives;
    private Vector3 charaPosition;
    public float recX, recY;
    private void Start()
    {
        livesCounter = defaultLives;
    }
    private void Update()
    {
        lives.text = "x " + livesCounter;
        charaPosition = playerController.transform.position;
    }
    public void TakeLife()
    {
        livesCounter--;
        Debug.Log("You lost One Life");
        charaPosition.x = recX;
        charaPosition.y = recY;
        playerController.transform.position = charaPosition;
        if (livesCounter < 1)
        {
            playerController.KillPlayer();
        }
    }
}
