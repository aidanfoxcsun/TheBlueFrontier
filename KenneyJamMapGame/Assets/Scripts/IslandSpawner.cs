using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    public GameObject[] islandPrefabs;
    private List<GameObject> islandSpawns;
    int totalIslands = 0;


    void Awake()
    {
        List<GameObject> tmpIslands = islandPrefabs.ToList();
        islandSpawns = GameObject.FindGameObjectsWithTag("SpawnPoint").ToList();
        if(islandSpawns.Count >= tmpIslands.Count)
        {
            totalIslands = tmpIslands.Count;
        }
        else
        {
            totalIslands = islandSpawns.Count;
        }

        for(int i = 0; i < totalIslands; i++)
        {
            int SpawnLocation = Random.Range(0, islandSpawns.Count);
            int Island = Random.Range(0, tmpIslands.Count);
            Instantiate(tmpIslands[Island], islandSpawns[SpawnLocation].transform);
            islandSpawns.RemoveAt(SpawnLocation);
            tmpIslands.RemoveAt(Island);
        }

    }

    
}
