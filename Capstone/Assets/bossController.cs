using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        //should ignore hitting other player projectiles if they end up overlapping
        if (collision.gameObject.CompareTag("player")){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
            //Debug.Log("Projectile collision with other projectile, ignoring collision");
            return;
        }
        if (collision.gameObject.CompareTag("projectile")){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
            return;
        }
    }
}
