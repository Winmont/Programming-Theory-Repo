using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{
    int attackDamage = 5;
    float attackRange = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit,attackRange))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red, attackRange);
    }

    private void Move()
    {
        transform.Translate((Vector3.right *Input.GetAxis("Horizontal")+Vector3.forward*Input.GetAxis("Vertical")).normalized*moveSpeed*Time.deltaTime);
    }
}
