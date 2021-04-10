﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolController : MonoBehaviour
{
    public Animator animator;
    private LivesManager livesManager;
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;

    private void Start()
    {
        livesManager = FindObjectOfType<LivesManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Enemy Collided with Player");
            livesManager.recX = 24.24f;
            livesManager.recY = 5.0f;
            livesManager.TakeLife();
            //SceneManager.LoadScene(1);
        }
    }
}
