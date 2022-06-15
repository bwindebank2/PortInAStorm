using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;

    private void Update()
    {
        if(health <= 0)
        {
            // Die
            Debug.Log(gameObject + "has died");
            Destroy(gameObject, 0.1f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }

}
