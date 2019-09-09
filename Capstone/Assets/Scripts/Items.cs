using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject player;
    public int newSpeed = 5;
    //public Color color = Color.red;
    public int scale = 0;
    public string debug = "Enter Message";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Change the speed 
        if (newSpeed > 5)
        {
            player.GetComponent<CharacterController>().speed = newSpeed;
        }
        Debug.Log("Picked Up Item: " + debug);
        player.transform.localScale += new Vector3(scale, scale, scale);
        // Player has no renderer
        // player.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
        Destroy(gameObject);
    }
}
