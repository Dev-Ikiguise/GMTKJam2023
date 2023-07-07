using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float enemySpeed;
    public float enemyHealth;
    public float proximityFromPlayer;

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
    }

}
