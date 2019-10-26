using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madness : MonoBehaviour
{

	public float maxMadness;
	public float currentMadness;
	public Slider madnessBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        madnessBar.value = currentMadness / maxMadness;
    }
}
