using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed by Player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            SoundManager.Instance.PlayOnce(SoundsForEvents.LevelComplete);
            SceneManager.LoadScene(5);
        }
    }
}
