using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{
    
    private float attackDamage = 20;
    private float attackSpeed = 1.0f;

    private void Start()
    {
        //itemName = "axe";
    }

    public override float[] useItem()
    {
        return new float[] { attackDamage, attackSpeed };
    }

    public override string GetItemName()
    {
       return "axe";
    }

}
