using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerSpawn;

    public Transform currentPlayer;

    void Start()
    {
        spawnPlayer();  
    }

    void spawnPlayer()
    {
        if (playerPrefab != null && currentPlayer == null)
        {
            currentPlayer = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity).transform;

            CameraTracker.instance.target = currentPlayer;
        }
    }
}
