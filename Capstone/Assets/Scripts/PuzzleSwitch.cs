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
    public PuzzleSwitch left;
    public PuzzleSwitch right;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = this.offSprite;
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

        this.left.isOn = !this.left.isOn;
        if (this.left.isOn){this.left.spriteRenderer.sprite = onSprite;}
        else {this.left.spriteRenderer.sprite = offSprite;}
        
        this.right.isOn = !this.right.isOn;
        if (this.right.isOn){this.right.spriteRenderer.sprite = onSprite;}
        else {this.right.spriteRenderer.sprite = offSprite;}
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (!transform.parent.gameObject.GetComponent<SwitchPuzzle>().isSolved){
        	if(collision.gameObject.tag == "projectile"){
        		toggle();
        		transform.parent.gameObject.GetComponent<SwitchPuzzle>().checkSolved();
        	} 
        }
    }
}
