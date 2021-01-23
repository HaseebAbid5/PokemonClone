using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Databox;

public class SaveButton : MonoBehaviour
{
    public DataboxObject data;
    // Start is called before the first frame update

    void Awake()
    {
        data.LoadDatabase();
    }

    public void SaveButtonClicked()
    {
        data.SaveDatabase();
    }
}
