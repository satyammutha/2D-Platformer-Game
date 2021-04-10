using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public int defaultLives;
    public int livesCounter;
    public TextMeshProUGUI lives;
    private Vector3 charaPosition;
    private PlayerController playerController;
    private GameOverController gameOverController;
    public float recX, recY;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameOverController = FindObjectOfType<GameOverController>();
        livesCounter = defaultLives;
    }
    private void Update()
    {
        
        lives.text = "x " + livesCounter;
        charaPosition = playerController.transform.position;
        if(livesCounter < 1)
        {
            //Debug.Log("Game Over");
            playerController.KillPlayer();
        }
    }
    public void TakeLife()
    {
        livesCounter--;
        Debug.Log("You lost One Life");
        charaPosition.x = recX;
        charaPosition.y = recY;
        playerController.transform.position = charaPosition;
        
    }
}
