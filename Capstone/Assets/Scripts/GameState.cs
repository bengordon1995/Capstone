using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    private static GameState _instance;
    public static GameState Instance { get { return _instance; } }

    public GameObject player;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            _instance.player = GameObject.Find("Player");
        }
    }

    void Start(){
        
    }

}