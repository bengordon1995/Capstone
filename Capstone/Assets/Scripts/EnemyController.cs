using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyState
{

    AIM,

    CHARGE,

    RECOVER

};

public class EnemyController : MonoBehaviour
{

    GameObject player;
    public EnemyState currState = EnemyState.AIM;
    public float speed;
    private Vector3 randomDir;
    public bool isColliding = false;
    public float damage;
    public GameObject healthBarPrefab;
    public GameObject healthBar;
    public Slider healthBarSlider;
    public DamageableHealth damageableHealth;
    public float knockbackScaling;


    public float aimTime;
    public float chargeTime;
    public float recoverTime;

    public float elapsedStateTime;
    public float lastStateTime;
    public Vector3 chargeDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameState.Instance.player;
        this.healthBar = Instantiate(healthBarPrefab);
        this.healthBar.transform.parent = GameObject.Find("Canvas").transform;
        this.GetComponent<DamageableHealth>().healthBar = this.healthBar.GetComponent<Slider>();
        this.healthBar.GetComponent<HealthBarFollower>().followObject = this.gameObject;
        this.healthBar.GetComponent<HealthBarFollower>().offset = new Vector3(0f,-0.5f,0f);
        this.damageableHealth = this.GetComponent<DamageableHealth>();

    }

    // Update is called once per frame
    void Update()
    {
    	elapsedStateTime += Time.deltaTime;
    	if (currState == EnemyState.AIM){
    		if (elapsedStateTime > aimTime){
    			currState = EnemyState.CHARGE;
    			chargeDirection = (GameState.Instance.player.transform.position - this.transform.position).normalized;
    			elapsedStateTime = 0f;
    		}
    		else{
    			Aim();
    		}
    	}
		else if (currState == EnemyState.CHARGE){
    		if (elapsedStateTime > chargeTime){
    			this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    			currState = EnemyState.RECOVER;
    			elapsedStateTime = 0f;
    		}
    		else{
    			Charge();
    		}
    	}
    	else if (currState == EnemyState.RECOVER){
    		if (elapsedStateTime > recoverTime){
    			currState = EnemyState.AIM;
    			elapsedStateTime = 0f;
    		}
    		else{
    			Aim();
    		}
    	}
    }

    public void Aim(){
    	this.GetComponent<Rigidbody2D>().velocity = (GameState.Instance.player.transform.position - this.transform.position).normalized * speed / 4;
		transform.right = GameState.Instance.player.transform.position - transform.position;    
	}

    public void Charge(){
    	this.GetComponent<Rigidbody2D>().velocity = chargeDirection * speed;
    }

    public void Recover(){
    	return;
    }
   

    void Follow()
    {
        GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized*speed;
    }

    void OnCollisionEnter2D(Collision2D collision){
    	if(collision.gameObject.tag == "projectile"){
    		this.damageableHealth.currentHealth -= collision.gameObject.GetComponent<Projectile>().damage;
    		if(this.damageableHealth.currentHealth <= 0){
    			Destroy(this.gameObject);
    			Destroy(this.healthBar);
    		}
    	}
    	if(collision.gameObject.tag == "Player"){
    		GameState.Instance.player.GetComponent<DamageableHealth>().currentHealth -= this.damage;
    		Vector2 knockbackVector = (GameState.Instance.player.transform.position - this.transform.position).normalized * (this.damage / knockbackScaling);
    		GameState.Instance.player.GetComponent<Rigidbody2D>().velocity += knockbackVector;
    		this.GetComponent<Rigidbody2D>().velocity -= knockbackVector;
    	}
    	isColliding = true;
    	StartCoroutine(tempDisableWallCollision());
    }

    private IEnumerator tempDisableWallCollision(){
        Collider2D wallCollider = GameObject.Find("Walls").GetComponent<Collider2D>();
    	Physics2D.IgnoreCollision(GetComponent<Collider2D>(), wallCollider);
    	yield return new WaitForSeconds(0.1f);
    	Physics2D.IgnoreCollision(GetComponent<Collider2D>(), wallCollider, false);
    }
}
