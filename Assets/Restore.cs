using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Databox;

public class Restore : MonoBehaviour
{
    public DataboxObject data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            data.ResetToInitValues("Data");
        }
        

    }
}
