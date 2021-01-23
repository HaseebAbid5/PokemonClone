using UnityEngine;
using Databox;

public class Restore : MonoBehaviour
{
    public DataboxObject data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            data.SetData<IntType>("Data","Player","Pokeballs", new IntType(5));
        }
    }
}
