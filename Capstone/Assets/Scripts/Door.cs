using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

	public bool locked = true;

    void OnCollisionEnter2D(Collision2D collision){
    	if (collision.gameObject == GameState.Instance.player){
            if(!locked){
    		  RoomManager.Instance.roomTransition();
            }
    	}
    }
}
