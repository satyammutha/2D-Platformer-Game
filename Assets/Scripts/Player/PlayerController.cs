using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_collider;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float Jump;
    public ScoreController scoreController;
    public GameOverController gameOverController;
    private LivesManager livesManager;
    private String _JUMP_AXIS = "Jump";
    private String _HORIZONTAL_AXIS = "Horizontal";
    private Vector2 scale;
    private Rigidbody2D rb2d;
    private Vector3 position;
    private float _DEFX = 0.42f, _DEFY = 1.99f;
    private float _DEFOX = 0.011f, _DEFOY = 0.98f;
    private int KeyCounter = 0;
    private bool isJump = false;
    
    public void KillPlayer()
    {
        gameOverController.PlayerDied();
        this.enabled = false;
    }
    internal void PickUpKey()
    {
        Debug.Log("Player Picked up a Key.");
        SoundManager.Instance.PlayOnce(SoundsForEvents.KeyPickup);
        KeyCounter++;
        scoreController.IncreaseScore(10);
        Debug.Log("Key Collected: " + KeyCounter);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Entered into Collision");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        livesManager = FindObjectOfType<LivesManager>();
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
        float vertical = Input.GetAxisRaw(_JUMP_AXIS);
        float horizontal = Input.GetAxisRaw(_HORIZONTAL_AXIS);
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
            SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerKilled);
            livesManager.recX = 5.43f;
            livesManager.recY = -2.37f;
            livesManager.TakeLife();
        }
    }

    private void MoveCharacter(float horizontal)
    {
        //move character horizontally
        //speed * Time.deltaTime == (Distance / Time) * (1 / Frames per second)
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
    private void PlayJumpSound()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerJump);
    }
    private void PlayStepJumpSound()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerStepJump);
    }
    private void PlayStepJumpLandSound()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerStepJumpLand);
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {        
        // Get Input from Left Right keys and Run on that sides
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        scale.x = horizontal < 0 ? -1f * Mathf.Abs(scale.x) : Mathf.Abs(scale.x) ;
        transform.localScale = scale;

        // Get Input from Spacebar key and Run Jump Animations
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
