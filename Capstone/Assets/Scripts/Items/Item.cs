using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Picked Up Item: " + this.GetType());
        //calls the specific behavior of the subclass on the player
        this.powerUpAction();
        Destroy(gameObject);
    }

    protected virtual void powerUpAction(){
        return;
    }
}
