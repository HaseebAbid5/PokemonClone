using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Databox;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public DataboxObject data;
    public Text text;

    private void Update()
    {
        text.text = data.GetData<IntType>("Data", "Player", "Pokeballs").Value.ToString();
        
    }
}
