using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

	public float degreesPerSecond = 10;
	public float timeSinceChange;
	public float timePerChange;
	public int[] ratios = {10,20,30,40};
	public int ratioIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceChange = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	// this.timeSinceChange += Time.deltaTime;
    	// if(timeSinceChange > timePerChange){
    	// 	timeSinceChange = 0;
    	// 	ratioIndex = (ratioIndex + 1) % 3;
    	// 	this.degreesPerSecond = ratios[ratioIndex];
    	// }
        this.transform.Rotate(0,0, degreesPerSecond * Time.deltaTime);
    }
}
