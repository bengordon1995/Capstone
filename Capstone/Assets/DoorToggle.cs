using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToggle : MonoBehaviour
{
	public bool isRoomActive;
	public bool isRoomComplete;

    // Start is called before the first frame update
    void Start()
    {
    	isRoomActive = true;
        isRoomComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRoomComplete){
        	this.gameObject.SetActive(false);
        }
        else{
        	this.gameObject.SetActive(true);
        }
    }
}
