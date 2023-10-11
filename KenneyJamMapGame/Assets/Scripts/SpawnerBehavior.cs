using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public IslandType type;

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Island>() != null)
        {
            this.type = other.GetComponent<Island>().type;
        }
    }

    public IslandType GetIslandType()
    {
        return this.type;
    }
}
