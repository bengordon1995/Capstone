using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{

	public GameObject nextRoom;
    public bool locked;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    public GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
    	if (collision.gameObject == GameState.Instance.player){
            if(!locked){
    		  roomSwitch();
            }
    	}
    }

    public void unlock(){
        this.locked = false;
        foreach (GameObject door in this.doors){
            door.GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        }
    }

    void roomSwitch(){
        GameState.Instance.currentRoomTrigger = Instantiate(nextRoom).GetComponent<RoomTrigger>();
        Destroy(this);
    	GameState.Instance.player.transform.position = new Vector3(-8.5f,0.5f,0);
    }
}
