using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UICrosses : MonoBehaviour
{
    public List<GameObject> crosses;

    // Start is called before the first frame update
    void Start()
    {
        crosses.Clear();
        for(int i = 0; i < 8; i++)
        {
            crosses.Add(GameObject.Find("Cross_" + i));
        }
        
        foreach(GameObject cross in crosses)
        {
            cross.SetActive(false);
        }
    }

    
}
