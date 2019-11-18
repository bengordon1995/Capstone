using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool locked;
    public GameObject[] doors;
    public GameObject[] rewards;

    // Start is called before the first frame update
    void Start()
    {
        rewards = GameObject.FindGameObjectsWithTag("reward");
        foreach (GameObject reward in rewards){
            reward.SetActive(false);
        }
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
        foreach (GameObject reward in rewards){
            reward.SetActive(true);
        }

        this.locked = false;
        for (int i = 0; i < this.doors.Length; i++){
            if(doors[i].name == "Exit"){
                doors[i].GetComponent<Door>().unlockDoor();
            }
        }
    }
}
