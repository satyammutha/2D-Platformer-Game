using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 scale;
    public BoxCollider2D m_collider;
    public Animator animator;
    public float _defX = 0.42f, _defY = 1.99f;
    public float speed;
    private Rigidbody2D rb2d;
    public float Jump;
    private bool isJump = false;
    private Vector3 position;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered into Collision");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        scale = transform.localScale;
        m_collider = GetComponent<BoxCollider2D>();
        m_collider.size = new Vector2(0.42f, 1.99f);
    }
    private void Update()
    {
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        float vertical = Input.GetAxisRaw("Jump");
        float horizontal = Input.GetAxisRaw("Horizontal");
        position = transform.position;

        PlayMovementAnimation(horizontal, vertical);
        ControlBtnCrouch(Crouch);
        ResizeCollider(Crouch);
        MoveCharacter(horizontal);
        deathRestart();
    }

    private void deathRestart()
    {
        if(position.y < -10)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void MoveCharacter(float horizontal)
    {
        //move character horizontally
        //speed * Time.deltaTime == (Distance / Time) * (1 / Frames per second)
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move character vertically
        //if (vertical > 0)
        //{
        //    rb2d.AddForce(new Vector2(0, Jump), ForceMode2D.Force);
        //}
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        // Get Input from Left Right keys and Run on that sides
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        // Get Input from Up down keys and Run Jump Animations
        if (vertical > 0 && isJump)
        {
            animator.SetBool("Jump", isJump);
            rb2d.AddForce(new Vector2(0, Jump), ForceMode2D.Force);
            isJump = false;
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void ControlBtnCrouch(bool Crouch)
    {
        // If we pressed LeftControl key then it plays Crouch animation
        animator.SetBool("isCrouch", Crouch);
    }

    private void ResizeCollider(bool Crouch)
    {
        float resX = 0.42f;
        float resY = 1.2f;
        //resize collider
        if (Crouch == true)
        {
            m_collider.size = new Vector2(resX, resY);
            //m_collider.offset = new Vector2(resX, resY);
        }
        else
        {
            m_collider.size = new Vector2(_defX, _defY);
        }
    }
}
