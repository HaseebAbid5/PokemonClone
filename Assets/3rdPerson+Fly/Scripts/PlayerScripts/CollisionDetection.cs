using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
       // if (collision.transform.tag.Equals("Ground"))
            //this.gameObject.SetActive(false);
        //Collided(collision.transform.gameObject);
    }
   
}
