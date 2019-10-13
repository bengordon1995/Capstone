using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Used for storing global variables around
*/

public class GameState : MonoBehaviour {
    private static GameState _instance;
    public static GameState Instance { get { return _instance; } }

    public Room currentRoom;
    public GameObject player;

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
        _instance.currentRoom = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        _instance.player = GameObject.Find("Player");
    }

}