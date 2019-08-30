using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

	public float reloadTime;
	public float projectileSize;
	public float projectileSpeed;
	public GameObject projectilePrefab;

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
        timeSinceLastProjectile += Time.deltaTime;
        if (timeSinceLastProjectile > reloadTime){
        	if(Input.GetKeyDown("space")){
        		GameObject newProj = Instantiate(projectilePrefab, player.transform.position,  new Quaternion());
        		newProj.GetComponent<Rigidbody2D>().velocity = player.GetComponent<CharacterController>().direction.normalized * projectileSpeed;
        		timeSinceLastProjectile = 0;
        	}
        }
    }
}
