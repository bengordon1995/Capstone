using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//generates a new level using a recursive function, which selects from prefabs representing rooms
public class LevelGenerator : MonoBehaviour
{
	public GameObject room;

	//between 0 and 1, represents chance for each room to generate a new room in each direction
	public float roomDensity;
	public float roomWidth;
	public float roomHeight;
	public int maxDepth;
    // Start is called before the first frame update
    void Start()
    {
        generate(0, 0, 0, 0, 0);
    }

    void generate( int depth, int x, int y, int prevX, int prevY){
    	if (depth == maxDepth){
    		return;
    	}
    	
    	//TODO: select a room from list of room prefabs instead of single room
    	GameObject newRoom = Instantiate(room, new Vector3(x * roomWidth, y * roomHeight, 0), Quaternion.identity);
        newRoom.transform.parent = this.transform;
    	
    	//up 
    	if(Random.Range(0.0f, 1.0f) < roomDensity){
    		generate(depth + 1, x, y + 1, x, y );
		}
    	//down
		if(Random.Range(0.0f, 1.0f) < roomDensity){
    		generate(depth + 1, x, y - 1, x, y );
    	}
    	//left
		if(Random.Range(0.0f, 1.0f) < roomDensity){
    		generate(depth + 1, x - 1, y, x, y );
    	}
    	//right
		if(Random.Range(0.0f, 1.0f) < roomDensity){
    		generate(depth + 1, x + 1, y, x, y );
    	}
    }
}
