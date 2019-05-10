using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance;

    public GameObject playerPrefab;

    public Transform playerSpawn;



    private void Awake()
    {
        instance = this;
    }

    public void spawnPlayer()
    {
        if (playerPrefab != null && GameController.instance.currentPlayer == null)
        {
            GameController.instance.currentPlayer = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity).transform;

            HealthController.instance.addHeart(GameController.instance.currentPlayer.GetComponent<PlayerController>().getPlayerCurrentHealth());

            CameraTracker.instance.target = GameController.instance.currentPlayer;
        }
    }
}
