using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    public bool isWalking;

    private void Update()
    {
        isWalking = true;
        EnemyMovement(isWalking);
    }

    private void EnemyMovement(bool isWalking)
    {
        Vector3 position = transform.position;
        if (isWalking)
        {
            position.x += 1 * Time.deltaTime;
            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("Enemy Collided with Player");
            playerController.KillPlayer();
        }
    }
}
