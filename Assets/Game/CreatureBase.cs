using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureBase", menuName ="Creature/New Creature")]
public class CreatureBase : ScriptableObject {

     [SerializeField] string name;

     [TextArea]
     [SerializeField] string description;

     [SerializeField] GameObject model;

     [SerializeField] CreatureType creatureType;

     //Base Stats

     [SerializeField] int maxHP;
     [SerializeField] int attack;
     [SerializeField] int defense;
     [SerializeField] int spAttack;
     [SerializeField] int spDefense;
     [SerializeField] int speed;

     [SerializeField] List<LearnableMove> learnableMoves;


     public string Name{
         get{return name;}
     }
     public string Description{
         get{return description;}
     }
    public GameObject Model{
         get{return model;}
     }
    public CreatureType CType{
         get{return creatureType;}
     }
    public int MaxHP{
         get{return maxHP;}
     }
    public int Attack{
         get{return attack;}
     }
    public int Defense{
         get{return defense;}
     }
    public int SPAttack{
         get{return spAttack;}
     }
    public int SPDefense{
         get{return spDefense;}
     }
    public int Speed{
         get{return speed;}
     }
     public List<LearnableMove> LearnableMoves{
         get{return learnableMoves;}
     }
}

[System.Serializable]
public class LearnableMove{

    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base{
        get{return moveBase;}
    }

    public int Level{
        get{return level;}
    }
}


public enum CreatureType{

    Physical,
    Fire,
    Water,
    Electric,
    Grass,
    Rock
}
