using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public GameObject player;
    public float range = 5.0f, speed = 2.0f, space = 2.0f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) > range)
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, speed);
            GetComponent<Animator>().SetBool("isWalking", true);

        }
        else { 
            GetComponent<Animator>().SetBool("isWalking", false);
        }

    }
}
