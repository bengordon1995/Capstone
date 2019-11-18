using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealth : Item

{
    public float health = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void powerUpAction()
    {
        GameObject.Find("Player").GetComponent<DamageableHealth>().maxHealth += health;
        GameObject.Find("Player").GetComponent<DamageableHealth>().currentHealth += health;
    }


}

