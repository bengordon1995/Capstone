using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
	public Quaternion rotation;
	public GameObject projectilePrefab;
	public Vector3[] path;
	public float timeSinceEmit;
	public float timeBetweenEmit;
	public CompositeEmitter parentEmitter;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceEmit = 0;
        this.path = this.GetComponent<Path>().path;
        this.path = compensatePath();
    }

    // Update is called once per frame
    void Update()
    {
    	timeSinceEmit += Time.deltaTime;
        if (timeSinceEmit > timeBetweenEmit){
        	timeSinceEmit = 0;
        	Emit();
        }
    }

    void Emit(){
    	//check if there is an inactive proj ready to activate
    	GameObject tempProj = parentEmitter.popInactiveProjectile();
    	//no inactive objects were found
    	if (tempProj == null){
    		tempProj = Instantiate(projectilePrefab, this.path[0], this.rotation);
	    	tempProj.GetComponent<PointPathFollower>().pathMarkers = compensatePath();
    	}
    	//tempProj currently contains an inactive projectile
    	else{
    		tempProj.SetActive(true);
    		tempProj.GetComponent<PointPathFollower>().pathMarkers = compensatePath();
    		tempProj.transform.position = tempProj.GetComponent<PointPathFollower>().pathMarkers[0];
    		tempProj.GetComponent<PointPathFollower>().currentPathMarker = tempProj.GetComponent<PointPathFollower>().pathMarkers[0];
        	tempProj.GetComponent<PointPathFollower>().nextPathMarker = tempProj.GetComponent<PointPathFollower>().pathMarkers[1];
        	tempProj.GetComponent<PointPathFollower>().nextPathMarkerIndex = 1;
        	tempProj.GetComponent<PointPathFollower>().timeSinceMove = 0;
    	}
	    
	    this.parentEmitter.pushProjectile(tempProj);

    }

    Vector3[] compensatePath(){
    	Vector3[] newPath = new Vector3[this.path.Length];
    	for (int i = 0; i < this.path.Length; i++){
    		Vector3 tempPoint = RotatePointAroundPivot(this.path[i], this.transform.parent.position, this.transform.parent.rotation.eulerAngles + this.transform.rotation.eulerAngles);
    		newPath[i] = tempPoint;
    	}
    	return newPath;
    }


	public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
		return Quaternion.Euler(angles) * (point - pivot) + pivot;
	}

}
