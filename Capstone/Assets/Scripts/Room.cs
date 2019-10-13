using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

	public GameObject nextRoom;
    public bool locked;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    public GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        this.doors = GameObject.FindGameObjectsWithTag("door");
        this.locked = true;
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
        for (int i = 0; i < this.doors.Length; i++){
            doors[i].GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        }
    }

    void roomSwitch(){
        GameState.Instance.currentRoom = Instantiate(nextRoom).GetComponent<Room>();
        Destroy(this);
    	GameState.Instance.player.transform.position = new Vector3(-8.5f,0.5f,0);
    }
}
