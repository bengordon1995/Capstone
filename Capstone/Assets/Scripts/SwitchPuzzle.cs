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
	public GameObject[] switches;
	public GameObject switchPrefab;
	public float puzzleRadius;

    // Start is called before the first frame update
    void Start()
    {
    	this.isSolved = false;
    	GameObject[] switches = new GameObject[5];
    	//instantiates 5 switches located around the center of the puzzle prefab
        for (int i = 0; i < 5; i++){
        	Vector3 tempSwitchLocation = this.gameObject.transform.position + Quaternion.Euler(0,0,72*i) * Vector3.up * puzzleRadius;
        	GameObject tempSwitch = GameObject.Instantiate(switchPrefab, tempSwitchLocation, Quaternion.identity) as GameObject;
        	tempSwitch.transform.SetParent(this.transform);
        	switches[i] = tempSwitch;
        	
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks if all switches are on
    public bool checkSolved(){
    	foreach (GameObject tempSwitchPrefab in this.switches){
    		if (tempSwitchPrefab.GetComponent<PuzzleSwitch>().isOn == false){
    			return false;
    		}
    	}
    	this.isSolved = true;
    	return true;
    }
}
