using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool locked;
    public GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        this.doors = GameObject.FindGameObjectsWithTag("door");
        foreach (GameObject tempDoorObj in this.doors){
            tempDoorObj.AddComponent<Door>();
            Door tempDoor = tempDoorObj.GetComponent<Door>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlock(){
        this.locked = false;
        for (int i = 0; i < this.doors.Length; i++){
            if(doors[i].name == "Exit"){
                doors[i].GetComponent<Door>().unlockDoor();
            }
        }
    }
}
