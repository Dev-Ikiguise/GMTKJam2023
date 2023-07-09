using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform player;
    public Transform enemy;


    public float enemyMoveSpeed;
    public float proximityFromPlayer;
    public float doubleDashFromPlayer;
    public float decelerationRate;

    //private Vector2 directionToFace;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
