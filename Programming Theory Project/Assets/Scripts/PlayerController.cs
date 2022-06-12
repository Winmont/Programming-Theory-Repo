using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : Unit // INHERITANCE
{
    float baseAttackDamage = 5;
    float baseAttackSpeed = 1.0f;
    float attackRange = 1.0f;
    float attackSpeed = 1.0f;
    float attackTimer = 0.0f;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject sword;
    [SerializeField] Item activeItem;
    [SerializeField] Text hpText;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject displayedItem;
    [SerializeField] List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
        health = 100.0f;
        moveSpeed = 5.0f;
        attackDamage = 5.0f;
        inventory.Add(axe.GetComponent<Item>());
        inventory.Add(sword.GetComponent<Item>());
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        Move();
        if (Input.GetMouseButtonDown(0) && attackTimer <= 0)
        {
            Attack();
            attackTimer = attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            unequipItem();
            EquipItem(inventory[0]); // ABSTRACTION
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            unequipItem();
            EquipItem(inventory[1]);
        }
    }

    private void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red, attackRange);
    }

    private void Move()
    {
        transform.Translate((Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical")).normalized * moveSpeed * Time.deltaTime);
    }

    private void EquipItem(Item item)
    {
        Debug.Log(item.GetItemName() + " was equipped");// ENCAPSULATION
        if (item.GetItemName() == "axe")
        {
            displayedItem = Instantiate(axe, hand.transform.position,Quaternion.identity,hand.transform);
            displayedItem.transform.localScale = Vector3.one * 0.2f;
            displayedItem.transform.rotation = Quaternion.Euler(270.0f, 0.0f, 180.0f);
        }
        else if (item.GetItemName() == "sword")
        {
            displayedItem = Instantiate(sword, hand.transform.position,Quaternion.identity,hand.transform);
            displayedItem.transform.localScale = Vector3.one * 0.2f;
            displayedItem.transform.rotation = Quaternion.Euler(270.0f, 0.0f, 180.0f);
        }
        activeItem = item;
        attackDamage = item.useItem()[0];
        attackSpeed = item.useItem()[1];
    }

    private void unequipItem()
    {
        Destroy(displayedItem);
        activeItem = null;
        attackDamage = baseAttackDamage;
        attackSpeed = baseAttackSpeed;
    }

    protected override void UpdateHealth() // POLYMORPHISM
    {
        hpText.text = "Player HP: " + health;
    }
}
