using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DamageableHealth : MonoBehaviour
{

    public Slider healthBar;
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    void Update ()
    {
        healthBar.value = currentHealth / maxHealth;
        if (this.currentHealth == 0){
            SceneManager.LoadScene("GameOver");
        }
    }

    public void damage(int damage){
        this.currentHealth -= damage;
    }
}
