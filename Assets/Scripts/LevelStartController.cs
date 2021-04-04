﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Player start 1(this) level");
            Destroy(gameObject);
        }
    }
}
