using UnityEngine;

public class EnemyPatrolController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private Animator animator;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private Transform groundDetection;
    private bool movingRight = true;
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
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            Debug.Log("Enemy Collided with Player");
            SoundManager.Instance.PlayOnce(SoundsForEvents.PlayerKilled);
            livesManager.recX = -1.5f;
            livesManager.recY = -2f;
            livesManager.TakeLife();
        }
    }
}
