using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag("Player")){
			Destroy(RoomManager.Instance.currentRoom);
            GameState.Instance.player.transform.position = new Vector3(0f,-3f,0f);
			RoomManager.Instance.currentRoom = Instantiate(RoomManager.Instance.entrancePrefab);
		}
	}
}
