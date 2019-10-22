using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Used for storing global variables around
*/

public class GameState : MonoBehaviour {
    private static GameState _instance;
    public static GameState Instance { get { return _instance; } }

    public GameObject player;
    public Room currentRoom;


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
        _instance.player = GameObject.Find("Player");
    }

}