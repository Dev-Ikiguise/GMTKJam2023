using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public int damage;
    public EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
            Debug.Log("GOAT IN");
           // enemyHealth.takeDamage(damage);
            //Debug.Log("Damage taken" + enemyHealth);
        }
    }
}
