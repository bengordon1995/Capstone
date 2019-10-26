using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableHealth : MonoBehaviour
{

    public Image healthBar;
    public float maxHealth = 100f;
    public float health;

    void Start()
    {
        healthBar = GetComponent<Image>();
        this.health = this.maxHealth;
    }

    void Update ()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
