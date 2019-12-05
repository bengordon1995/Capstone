using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRace : MonoBehaviour
{
    
    public GameObject targetItem;
    public GameObject[] checkpoints;
    public int currentTarget;
    public float speed;
    //public float targetProximity;
    public float checkpointProximity;
    public bool collected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            return;
        }
        if (currentTarget == -1 && !collected)//no objects to go to or player not close enough
        {
            collected = true;
            return;
        }
        if (Vector3.Distance(transform.position, checkpoints[currentTarget].transform.position) < checkpointProximity)//within x units of each other
        {
            currentTarget += 1;
            if (currentTarget == checkpoints.Length)//already reached the last one
            {
                currentTarget = -1;
                return;
            }
        }
        Vector3 direction = (checkpoints[currentTarget].transform.position - transform.position).normalized;//get direction of where to go
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag != "room" && tag != "Player" && tag!= "projectile" && tag!= "checkpoint")//if not colliding with player, bullets or room walls, then it must be the target item
        {
            collected = true;
        }
    }
}
