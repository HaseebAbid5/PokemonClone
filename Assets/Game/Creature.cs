using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature{

    public CreatureBase _base;
    int level;

    public int HP {get; set;}

    public List<Move> Moves {get; set;}

    public Creature(CreatureBase cBase, int clevel){

        _base = cBase;
        level = clevel;
        HP = _base.MaxHP;

        Moves = new List<Move>();
        
        foreach(var move in _base.LearnableMoves){

            if(move.Level <= level)
                Moves.Add(new Move(move.Base));

            if(Moves.Count >= 4)
                break;
        }
    }

    public int Attack{
        get{return _base.Attack + level;}
    }
    public int Defense{
        get{return _base.Defense + level;}
    }
    public int MaxHP{
         get{return _base.MaxHP + level;}
     }
    public int SPAttack{
         get{return _base.SPAttack + level;}
     }
    public int SPDefense{
         get{return _base.SPDefense + level;}
     }
    public int Speed{
         get{return _base.Speed + level;}
     }
     public GameObject CPrefab{
         get{return _base.Model;}
     }


}
