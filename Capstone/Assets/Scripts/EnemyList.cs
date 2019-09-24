using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//if no enemies left in the room, room is complete
        if(transform.GetChild(0) == null){
        	GameObject.Find("Doors").GetComponent<DoorToggle>().isRoomComplete = true;
        }
    }
}
