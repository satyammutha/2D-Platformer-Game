using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //Avoid tag compare, you may set player tag to anyone by mistake
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level Finished by Player");
        }
    }
}
