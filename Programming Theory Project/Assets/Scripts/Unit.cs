using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    protected int health;
    protected float moveSpeed;

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void TakeDamage(float amount)
    {
        health -= Mathf.CeilToInt(amount);
    }

   
}
