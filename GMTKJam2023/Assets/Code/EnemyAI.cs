using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    Rigidbody2D rb;
    public float enemyMoveSpeed;
    public float enemyHealth;
    public float proximityFromPlayer;

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

        // Use the distance for further actions or logic
        Debug.Log("Distance to player: " + distance);

        if (distance <= proximityFromPlayer)
        {
            Debug.Log("player is too close.");
            moveAwayFromPlayer();
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
        rb.velocity = Vector2.zero;
    }
    void moveAwayFromPlayer()
    {
        Vector2 directionToFace = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);
        transform.up = directionToFace;
        runAway();
    }


}
