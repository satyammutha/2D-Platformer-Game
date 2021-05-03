using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController)
        {
            Debug.Log("Player start level");
            Destroy(gameObject);
        }
    }
}
