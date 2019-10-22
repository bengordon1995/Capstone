using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Defines behavior for a switch puzzle:
	The switch puzzle has 5 switches arranged in a circle, each can either be on or off
	when a switch is toggled, it and the switches directly adjacent are toggled
	when all 5 switches are toggled on simultaneously, the puzzle is solved
*/

public class SwitchPuzzle : MonoBehaviour
{
	public bool isSolved;
	public List<PuzzleSwitch> switches = new List<PuzzleSwitch>();
	public GameObject switchPrefab;
	public float puzzleRadius;

    // Start is called before the first frame update
    void Start()
    {
    	this.isSolved = false;
    	//instantiates 5 switches located around the center of the puzzle prefab
        for (int i = 0; i < 5; i++){
        	Vector3 tempSwitchLocation = this.gameObject.transform.position + Quaternion.Euler(0,0,72*i) * Vector3.up * puzzleRadius;
        	GameObject tempSwitch = Instantiate(switchPrefab, tempSwitchLocation, Quaternion.identity);
        	tempSwitch.transform.SetParent(this.transform);
        	switches.Add(tempSwitch.GetComponent<PuzzleSwitch>());
        }

        //assign relationships
        //edge cases
        this.switches[0].right = this.switches[1];
        this.switches[0].left = this.switches[4];
        this.switches[4].left = this.switches[3];
        this.switches[4].right = this.switches[0];
        //center cases
        for (int i = 1; i < 4;i++){
        	this.switches[i].left = this.switches[i-1];
        	this.switches[i].right = this.switches[i+1];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks if all switches are on
    public void checkSolved(){
    	foreach (PuzzleSwitch tempSwitch in this.switches){
    		if (tempSwitch.isOn == false){
    			return;
    		}
    	}
    	this.isSolved = true;
        RoomManager.Instance.currentRoom.GetComponent<Room>().unlock();
    }
}
