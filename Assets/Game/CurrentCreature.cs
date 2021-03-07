using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCreature : MonoBehaviour
{
    [SerializeField] CreatureBase _base1,_base2;
    [SerializeField] int level;
    [SerializeField] Transform spawnPoint;

    public Creature creature {get; set;}
    GameObject active;


    void Start(){
        creature = new Creature(_base1, level);
        active = new GameObject();
        CreatureUpdate(_base1);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Keypad1)){
            CreatureUpdate(_base1);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2)){
            CreatureUpdate(_base2);
        }

        Debug.Log(creature.MaxHP);
    }

    void CreatureUpdate(CreatureBase _base){
        Destroy(active);
        creature._base = _base;
        active = Instantiate(_base.Model, spawnPoint.position, spawnPoint.rotation);
    }
}
