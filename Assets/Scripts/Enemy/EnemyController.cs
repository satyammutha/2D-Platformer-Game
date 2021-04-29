using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private bool isWalking;

    private void Update()
    {
        isWalking = true;
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        Vector3 position = transform.position;
        if(position.y < -7)
        {
            isWalking = false;
        }
        if (isWalking)
        {
            position.x += 1 * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            gameObject.SetActive(false);
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