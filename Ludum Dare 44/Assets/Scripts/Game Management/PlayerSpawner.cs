using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance;

    public GameObject playerPrefab;

    public Transform playerSpawn;

    public Transform currentPlayer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        spawnPlayer();  
    }

    void spawnPlayer()
    {
        if (playerPrefab != null && currentPlayer == null)
        {
            currentPlayer = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity).transform;

            HealthController.instance.addHeart(currentPlayer.GetComponent<PlayerController>().getPlayerCurrentHealth());

            CameraTracker.instance.target = currentPlayer;
        }
    }
}
