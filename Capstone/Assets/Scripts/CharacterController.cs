using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

	public float speed;
 
 	private Rigidbody2D rigid;

 	public float horizontal;
 	public float vertical;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	//inputs rounded to -1,0,1 values
    	horizontal = Input.GetAxisRaw("Horizontal");
    	vertical = Input.GetAxisRaw("Vertical");

    	this.rigid.transform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
    }
}
