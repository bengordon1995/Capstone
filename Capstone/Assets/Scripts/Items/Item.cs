using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Picked Up Item: " + this.GetType());
            //calls the specific behavior of the subclass on the player
            this.powerUpAction();
            Destroy(gameObject);
        }
        else
        {

            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.GetComponent<Collider2D>());
        }

    }

    protected virtual void powerUpAction(){
        return;
    }
}
