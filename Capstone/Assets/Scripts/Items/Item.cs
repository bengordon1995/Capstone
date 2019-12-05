﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
  
{
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
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Picked Up Item: " + this.GetType());
            //calls the specific behavior of the subclass on the player
            this.powerUpAction();
            Destroy(gameObject);
        }
    }

    protected virtual void powerUpAction(){
        return;
    }
}
