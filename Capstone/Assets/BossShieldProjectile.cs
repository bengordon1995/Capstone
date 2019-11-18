using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldProjectile : MonoBehaviour
{

	public int damage;
	public bool destroyed;

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
        if (collision.gameObject.CompareTag("player")){
        	if(!this.destroyed){
	            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponentInParent<CircleCollider2D>());
	            GameState.Instance.player.GetComponent<DamageableHealth>().damage(damage);
	            this.destroyed = true;
	            this.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}
