using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public IslandType type;
}

public enum IslandType{
    GrassyVillage,
    GrassyChest,
    RockyShipWreck,
    RockyPalm,
    SandyChest,
    SandyTent,
    Null
}
