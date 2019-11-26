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
    public Vector3 shootVector;
    
	private float timeSinceLastProjectile;

    public int numOfProjectile = 1;
    private int projectileAngle = 180;
    private int flipper = -1;
    private float newAngle;


    // Start is called before the first frame update
    void Start()
    {
     	timeSinceLastProjectile = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        //edits fire rate of player's projectiles
        timeSinceLastProjectile += Time.deltaTime;
        if (timeSinceLastProjectile > reloadTime){
        	if(Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("up") || Input.GetKey("down") ){
                Vector3 tempShootVector = new Vector3(Input.GetAxisRaw("HorizontalShoot"), Input.GetAxisRaw("VerticalShoot"), 0f);
                if (tempShootVector != Vector3.zero){
                    shootVector = tempShootVector;
                }
                horizontalShoot = shootVector.x;
                verticalShoot = shootVector.y;
                newAngle = projectileAngle / numOfProjectile;
                for (int i = 0; i < numOfProjectile; i++)
                {
                    GameObject newProj = Instantiate(projectilePrefab, GameState.Instance.player.transform.position + shootVector.normalized, Quaternion.identity);
                    //limit projectile flight time for performance
                    Destroy(newProj, projectileFlightTime);
                    newProj.GetComponent<Rigidbody2D>().velocity = shootVector.normalized * (projectileSpeed + GameState.Instance.player.GetComponent<PlayerController>().speed);

                    //Debug.Log("Angle is ");
                   // Debug.Log(newAngle * flipper);
                    if (numOfProjectile != 1)
                    {   
                        newProj.GetComponent<Rigidbody2D>().AddForce(new Vector3((newAngle * flipper) * verticalShoot, (newAngle * flipper) * horizontalShoot, 0f));
                        Debug.Log(horizontalShoot);
                        flipper *= -1;
                        newAngle += projectileAngle / numOfProjectile;
                        Debug.Log("angle: " + newAngle);

                    }

                    timeSinceLastProjectile = 0;
                }
        	}
        }
    }
}
