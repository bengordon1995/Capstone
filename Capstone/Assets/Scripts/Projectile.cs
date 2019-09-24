using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        //should ignore hitting other player projectiles if they end up overlapping
        if (collision.gameObject.CompareTag("projectile")){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponentInParent<CircleCollider2D>());
            Debug.Log("Projectile collision with other projectile, ignoring collision");
            return;
        }
        else if (collision.gameObject.CompareTag("player")){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponentInParent<CircleCollider2D>());
            Debug.Log("Ignoring collision with player");
            return;
        }
        Destroy(gameObject);            

    }
}
