using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	public float damage;

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
            return;
        }
        else if (collision.gameObject == GameState.Instance.player){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponentInParent<CircleCollider2D>());
            //Debug.Log("Ignoring collision with player");
            return;
        }
        else if (collision.gameObject.CompareTag("no_collide")){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponentInParent<CircleCollider2D>());
            Debug.Log("boss shielding: ignore collision");
        }
        else{
            Destroy(gameObject);            
        }
    }
}
