using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D m_collider;
    public float speed;
    public Vector2 scale;
    public bool Crouch;
    public float jump;
    public bool jumpBool;
    private void Start()
    {
        scale = transform.localScale;
        m_collider = GetComponent<BoxCollider2D>();
        m_collider.size = new Vector2(0.42f, 1.99f);
    }
    private void Update()
    {
        //Task1
        HorizontalKeysRun();
        ControlBtnCrouch();
        ResizeCollider();
        //Task2
        VerticalKeysJump();
    }

    private void HorizontalKeysRun()
    {
        // Get Input from Left Right keys and Run on that sides
        speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void ControlBtnCrouch()
    {
        // If we pressed LeftControl key then it plays Crouch animation
        Crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("isCrouch", Crouch);
        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    animator.SetBool("isCrouch", true);
        //}
        //else
        //{
        //    animator.SetBool("isCrouch", false);
        //}
    }

    private void ResizeCollider()
    {
        //resize collider
        if (Crouch == true)
        {
            m_collider.size = new Vector2(0.42f, 1.2f);
        }
        else
        {
            m_collider.size = new Vector2(0.42f, 1.99f);
        }
    }

    private void VerticalKeysJump()
    {
        // Get Input from Up down keys and Run Jump Animations
        jump = Input.GetAxisRaw("Vertical");
        jumpBool = false;
        if (jump == 1)
        {
            jumpBool = true;
            animator.SetBool("Jump", jumpBool);
        }
        else
        {
            jumpBool = false;
            animator.SetBool("Jump", jumpBool);
        }
    }
}
