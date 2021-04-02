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
    private Rigidbody2D rb2d;
    private Vector3 position;
    private float _DEFX = 0.42f, _DEFY = 1.99f;
    private float _DEFOX = 0.011f, _DEFOY = 0.98f;
    [SerializeField] private float speed;
    [SerializeField] private float Jump;
    private bool isJump = false;
    
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
        float characterDeadLine = -8f;
        if(position.y < characterDeadLine)
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
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        // Get Input from Left Right keys and Run on that sides
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        scale.x = horizontal < 0 ? -1f * Mathf.Abs(scale.x) : Mathf.Abs(scale.x) ;
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
        float _RESX = 0.65f;
        float _RESY = 1.21f;
        float _RESOX = -0.012f;
        float _RESOY = 0.59f;
        //resize collider
        if (Crouch == true)
        {
            m_collider.size = new Vector2(_RESX, _RESY);
            m_collider.offset = new Vector2(_RESOX, _RESOY);
        }
        else
        {
            m_collider.size = new Vector2(_DEFX, _DEFY);
            m_collider.offset = new Vector2(_DEFOX, _DEFOY);
        }
    }
}
