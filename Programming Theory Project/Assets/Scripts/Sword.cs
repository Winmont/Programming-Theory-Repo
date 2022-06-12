using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    private float attackDamage = 10;
    private float attackSpeed = 0.5f;

    private void Start()
    {
        //itemName = "sword";
    }

    public override float[] useItem()
    {
        return new float[] { attackDamage, attackSpeed };
    }

    public override string GetItemName()
    {
        return "sword";
    }
}
