using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform player;
    public Transform enemy;
    public Animator ani;


    public float enemyMoveSpeed;
    public float proximityFromPlayer;
    public float doubleDashFromPlayer;
    public float decelerationRate;

    public float currentFacing = -1f;

    //private Vector2 directionToFace;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between player and enemy
        float distance = Vector3.Distance(player.position, enemy.position);

        Vector2 playerDirectionLocal = enemy.transform.InverseTransformPoint(player.transform.position);

        if (playerDirectionLocal.x < 0)
        {
            ani.SetFloat("h", 1);
        }

        if (playerDirectionLocal.x > 0)
        {
            ani.SetFloat("h", -1);
        }

        if (distance <= proximityFromPlayer)
        {
            Debug.Log("player is too close.");
            moveAwayFromPlayer();
            if (distance <= doubleDashFromPlayer)
            {
                Debug.Log("double dashing");
                moveAwayFromPlayer();
            }

        }
        else
        {
            stopRunningAway();
            ani.SetFloat("speed", 0);
        }
    }

    void runAway()
    {
        rb.AddForce(transform.up * enemyMoveSpeed);
    }

    void stopRunningAway()
    {
        //transform.position = Vector2.Lerp(transform.position, Vector2.zero, decelerationRate * Time.deltaTime);
    }
    void moveAwayFromPlayer()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemyMoveSpeed * -Time.deltaTime);
        ani.SetFloat("speed", 1);
        //Vector2 directionToFace = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
        // transform.up = directionToFace;
        //runAway();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, proximityFromPlayer);
        Gizmos.DrawWireSphere(transform.position, doubleDashFromPlayer);

    }
}
