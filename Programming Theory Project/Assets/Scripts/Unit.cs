using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    protected float health;
    protected float moveSpeed;
    protected float attackDamage;
    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealth();
        if (health<=0)
        {
            Death();
        }
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        UpdateHealth();
        if (health <= 0)
        {
            Death();
        }
    
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    public void setDamage(float damage)
    {
        attackDamage = damage;
    }

    protected virtual void UpdateHealth()
    {
        
    }

}
