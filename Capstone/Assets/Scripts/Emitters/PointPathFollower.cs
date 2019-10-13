using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPathFollower : MonoBehaviour
{

	public Vector3[] pathMarkers;
	public Vector3 currentPathMarker;
    public Vector3 nextPathMarker;
	public int nextPathMarkerIndex;
    public float timeSinceMove;
	public float timeToMove;

    // Start is called before the first frame update
    void Start()
    {
        currentPathMarker = pathMarkers[0];
        nextPathMarker = pathMarkers[1];
        nextPathMarkerIndex = 1;
        timeSinceMove = 0;
        this.transform.position = this.pathMarkers[0];
    }

    // Update is called once per frame
    void Update(){
        timeSinceMove += Time.deltaTime;
        if (timeSinceMove > timeToMove){
            if(nextPathMarkerIndex + 1 == pathMarkers.Length){
                this.gameObject.SetActive(false);
            }
            else{
                currentPathMarker = nextPathMarker;
                nextPathMarkerIndex += 1;
                nextPathMarker = pathMarkers[nextPathMarkerIndex];
                timeSinceMove = 0;
            }
        }
        else{
            this.transform.localPosition = Vector3.Lerp(currentPathMarker, nextPathMarker, timeSinceMove / timeToMove);
        }
    }

    public void compOffset(Vector3 offset){
        this.transform.position += offset;
        for(int i = 0; i < this.pathMarkers.Length; i++){
            this.pathMarkers[i] += offset;
        }
    }
}