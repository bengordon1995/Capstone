using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

	public float reloadTime;
	public float projectileSize;
	public float projectileSpeed;
    public float projectileFlightTime;
	public GameObject projectilePrefab;

    public float horizontalShoot;
    public float verticalShoot;
    
	private float timeSinceLastProjectile;
	private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    	player = GameObject.Find("Player");
     	timeSinceLastProjectile = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        //edits fire rate of player's projectiles
        timeSinceLastProjectile += Time.deltaTime;
        if (timeSinceLastProjectile > reloadTime){
        	if(Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("up") || Input.GetKey("down") ){
                Vector3 shootVector = new Vector3(Input.GetAxisRaw("HorizontalShoot"), Input.GetAxisRaw("VerticalShoot"), 0f);
                horizontalShoot = shootVector.x;
                verticalShoot = shootVector.y;
        		GameObject newProj = Instantiate(projectilePrefab, player.transform.position + shootVector.normalized, Quaternion.identity);
                //limit projectile flight time for performance
                Destroy(newProj, projectileFlightTime);
                newProj.GetComponent<Rigidbody2D>().velocity = shootVector.normalized * (projectileSpeed + player.GetComponent<PlayerController>().speed);
        		timeSinceLastProjectile = 0;
        	}
        }
    }
}
