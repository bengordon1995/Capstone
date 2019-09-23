using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Represents a single switch in the adjacent switch puzzle
*/
public class PuzzleSwitch : MonoBehaviour
{

	public bool isOn;
	public SpriteRenderer spriteRenderer;
	public Sprite onSprite;
	public Sprite offSprite;
	public SwitchPuzzle puzzle;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //toggles the current isOn state and calls animation behaviors
    public void toggle(){
    	this.isOn = !this.isOn;
    	if (this.isOn){this.spriteRenderer.sprite = onSprite;}
    	else {this.spriteRenderer.sprite = offSprite;}
    }

    void OnCollisionEnter2D(Collision2D collision){
    	if(collision.gameObject.tag == "projectile"){
    		toggle();
    		puzzle.checkSolved();
    	} 
    }
}
