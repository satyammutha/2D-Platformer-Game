using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerController != null)
        {
            playerController.PickUpKey();
            Destroy(gameObject);
        }
    }
}
