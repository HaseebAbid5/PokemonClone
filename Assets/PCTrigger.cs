using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Databox;

public class PCTrigger : MonoBehaviour
{
    public DataboxObject data;
    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player")){
            Debug.Log("Press Submit to Save");
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag.Equals("Player")){
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Saved");
                data.SaveDatabase();
            }
        }
    }
}
