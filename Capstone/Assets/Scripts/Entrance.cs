using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : Room
{


	public Vector3 startCutscenePosition;
	public Vector3 endCutscenePosition;
	public float cutsceneTime;



    // Start is called before the first frame update
    void Start()
    {
        this.doors = GameObject.FindGameObjectsWithTag("door");
        foreach (GameObject tempDoorObj in this.doors){
            tempDoorObj.AddComponent<Door>();
            Door tempDoor = tempDoorObj.GetComponent<Door>();
        }
        StartCoroutine(introCutscene(startCutscenePosition, endCutscenePosition, cutsceneTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator introCutscene(Vector3 start, Vector3 end, float time){
    	float elapsedTime = 0f;
    	while (elapsedTime < time){
    		elapsedTime += Time.deltaTime;
    		GameState.Instance.player.transform.position = Vector3.Lerp(start, end, elapsedTime / time);
    		yield return null;
    	}
    	RoomManager.Instance.entrance.GetComponent<Entrance>().unlock();
    }

    public void unlock(){
        this.locked = false;
        for (int i = 0; i < this.doors.Length; i++){
                doors[i].GetComponent<Door>().unlockDoor();
        }
    }
}
