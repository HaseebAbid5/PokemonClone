using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    GameObject player;
    public float range = 5.0f, speed = 2.0f, space = 2.0f, initSpeed = 0f, boost = 1f, buffer;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        initSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) > range)
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, speed);
            GetComponent<Animator>().SetBool("isWalking", true);
            if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) > (range + buffer))
            {
                GetComponent<Animator>().SetBool("Roll", true);
                speed = initSpeed - boost;
            }
            else
            {
                GetComponent<Animator>().SetBool("Roll", false);
                speed = initSpeed;
            }

        }
        else { 
            GetComponent<Animator>().SetBool("isWalking", false);
        }

    }
}
