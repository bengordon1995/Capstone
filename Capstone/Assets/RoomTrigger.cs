using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{

	public GameObject room;
	public GameObject nextRoom;
	private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
    	if (collision.gameObject == player){
    		roomSwitch();
    	}
    }

    void roomSwitch(){
    	Destroy(room);
    	Instantiate(nextRoom);
    	player.transform.position = new Vector3(-8.5f,0.5f,0);
    }
}
