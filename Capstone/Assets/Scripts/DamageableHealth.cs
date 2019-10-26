using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableHealth : MonoBehaviour
{

    public Slider healthBar;
    public float maxHealth = 100f;
    public float health;

    void Start()
    {
        this.health = this.maxHealth;
    }

    void Update ()
    {
        healthBar.value = health / maxHealth;
    }
}
