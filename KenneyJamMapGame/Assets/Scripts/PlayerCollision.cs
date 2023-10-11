using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("SpawnPoint"))
        {
            Debug.Log("Shipwrecked!" + other);
            gameManager.GameOver();
        }
    }
}
