using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit
{
    [SerializeField] Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void UpdateHealth()
    {
        hpText.text = "Enemy HP: " + health;
    }


}
