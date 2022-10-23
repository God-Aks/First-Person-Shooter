using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;

     public void TakeDamage(float damage)
    {
        health-=damage;

        if(health<=0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
