using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

	public bool locked = true;

    void OnCollisionEnter2D(Collision2D collision){
    	if (collision.gameObject == GameState.Instance.player){
            if(!locked){
            	if(RoomManager.Instance.currentRoom == RoomManager.Instance.entrance){
            		this.lockDoor();
            	}
    			RoomManager.Instance.roomTransition();
            }
    	}
    }

    public void lockDoor(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = RoomManager.Instance.lockedSprite;
        this.gameObject.GetComponent<Door>().locked = true;
    }

    public void unlockDoor(){
		this.gameObject.GetComponent<SpriteRenderer>().sprite = RoomManager.Instance.unlockedSprite;
        this.gameObject.GetComponent<Door>().locked = false;
    }
}
