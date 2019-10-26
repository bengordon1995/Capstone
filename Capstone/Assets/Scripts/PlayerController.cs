using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed;
 	private Rigidbody2D rigid;
 	public float horizontal;
 	public float vertical;
    public Vector2 direction;
    public float maxSpeed;
    public float dragCoefficient;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        this.direction = new Vector2(0,-1);
    }

    // Update is called once per frame
    void Update()
    {
    	//inputs rounded to -1,0,1 values
    	horizontal = Input.GetAxisRaw("Horizontal");
    	vertical = Input.GetAxisRaw("Vertical");

    	this.rigid.velocity += new Vector2(horizontal,vertical).normalized * speed;

    	if (new Vector2(horizontal,vertical).sqrMagnitude < 1){
    		this.rigid.velocity = this.rigid.velocity * dragCoefficient;
    		if (this.rigid.velocity.sqrMagnitude < 0.05){
    			this.rigid.velocity = Vector2.zero;
    		}
    	}

    	if (this.rigid.velocity.sqrMagnitude > maxSpeed * maxSpeed){
    		this.rigid.velocity = this.rigid.velocity.normalized * maxSpeed;
    	}


    }
}
