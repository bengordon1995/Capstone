using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Used for storing global variables around
*/

public class RoomManager : MonoBehaviour {
    private static RoomManager _instance;
    public static RoomManager Instance { get { return _instance; } }

    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    public GameObject currentRoom;
    public GameObject nextRoom;
    public GameObject entrance;
    public float additionalRoomChance;
    public List<GameObject> roomPrefabs;
    public GameObject bossRoom;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start(){
        _instance.currentRoom = GameObject.FindGameObjectsWithTag("room")[0];
        _instance.entrance = _instance.currentRoom;

    }

    public void roomTransition(){
    	_instance.currentRoom.SetActive(false);
    	GameObject[] projectiles = GameObject.FindGameObjectsWithTag("projectile");
    	foreach(GameObject p in projectiles){
    		Destroy(p);
    	}
    	if (Random.Range(0.0f,1.0f) < additionalRoomChance){
    		_instance.nextRoom = Instantiate(roomPrefabs[Random.Range(0,this.roomPrefabs.Count)]);
            GameState.Instance.player.transform.position = new Vector3(-5f,0f,0f);
        }
        else {
            _instance.nextRoom = _instance.entrance;
            _instance.entrance.SetActive(true);
            GameState.Instance.player.transform.position = new Vector3(0f,-3f,0f);
        }
        
        _instance.currentRoom = _instance.nextRoom;
    }

    public void bossRoomTransition(){
		_instance.currentRoom.SetActive(false);
    	_instance.nextRoom = Instantiate(bossRoom);
    	GameState.Instance.player.transform.position = new Vector3(-3f,-0f,0f);
    	_instance.currentRoom = _instance.nextRoom;
    	Camera.main.transform.parent = GameState.Instance.player.transform;
    }
}