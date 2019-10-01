using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeEmitter : MonoBehaviour
{

	public List<GameObject> projectiles;
	public int maxProjectiles;

    // Start is called before the first frame update
    void Start()
    {
        projectiles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject popInactiveProjectile(){
    	foreach (GameObject proj in projectiles){
    		if (! proj.activeSelf){
    			return proj;
    		}
    	}
    	return null;
    }

    public bool pushProjectile(GameObject proj){
    	if (projectiles.Count < maxProjectiles){
    		projectiles.Add(proj);
    		return true;
    	}
    	return false;
    }

    public GameObject popActiveProjectile(){
    	foreach (GameObject proj in projectiles){
    		if (proj.activeSelf){
    			return proj;
    		}
    	}
    	return null;
    }

    public GameObject popRandomActiveProjectile(){
    	int selector = Random.Range(0,this.numActive());
    	return this.projectiles[selector];
    }

    public int numActive(){
    	int count = 0;
    	foreach (GameObject proj in projectiles){
    		if (proj.activeSelf){
    			count++;
    		}
    	}
    	return count;
    }


}
