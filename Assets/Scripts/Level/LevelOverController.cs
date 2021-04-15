using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //Avoid tag compare, you may set player tag to anyone by mistake
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level Completed by Player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(5);
        }
    }
}
