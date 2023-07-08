using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public EnemyHealth enemyHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            enemyHealth.takeDamage(damage);
            Debug.Log("Damage taken" + enemyHealth);
        }
    }
}
