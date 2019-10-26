using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyState
{

    Wander,

    Follow,

    Die

};

public class EnemyController : MonoBehaviour
{

    GameObject player;


    public EnemyState currState = EnemyState.Wander;

    public float range;

    public float speed;

    private bool chooseDir = false;

    private bool dead = false;

    private Vector3 randomDir;

    public bool isColliding = false;

    public float damage;

    public GameObject healthBarPrefab;

    public GameObject healthBar;

    public Slider healthBarSlider;

    public DamageableHealth damageableHealth;

    public float knockbackScaling;

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
        switch(currState)
        {
            case(EnemyState.Wander):
                Wander();
            break;
            case(EnemyState.Follow):
                Follow();
            break;
            case(EnemyState.Die):
                Die();

            break;
        }

        if(IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if(!IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }
    }

    private void Die(){
    	return;
    }


    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    void Wander()
    {
        if(!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }


        GetComponent<Rigidbody2D>().velocity = transform.forward*speed;
        if(IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
        if (isColliding){
        	isColliding = false;
        	transform.rotation = Quaternion.Euler(0,0,180) * transform.rotation;
        }

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
