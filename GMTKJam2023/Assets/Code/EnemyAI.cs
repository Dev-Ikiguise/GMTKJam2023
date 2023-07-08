using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform player;
    public Transform enemy;

    //Has to do with movement stuff
    public float enemyMoveSpeed;
    public float proximityFromPlayer;

    //enemy health and death
    public float enemyHealth;

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
        float distance = Vector3.Distance(player.position, enemy.position);

        if (distance <= proximityFromPlayer)
        {
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
