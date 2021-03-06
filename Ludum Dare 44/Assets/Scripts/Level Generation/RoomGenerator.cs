﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    //1 - bottom door, 2 - top door, 3 - left door, 4 - right door
    public int doorDirection;

    [SerializeField]
    private GameObject roomsParentPrefab = null, merchantSpawnerPrefab = null;

    [SerializeField]
    private GameObject[] bottomRooms = new GameObject[4], topRooms = new GameObject[4], leftRooms = new GameObject[4], rightRooms = new GameObject[4];

    [SerializeField]
    private GameObject closedRoom = null;

    public bool hasSpawned = false;

    //private int maxRooms = 500;

    private int rand;

    public float waitTime = 1f;


    private void Start()
    {
        Destroy(gameObject, waitTime);
        //genLevel();

        if (!GameObject.FindGameObjectWithTag("Rooms Parent"))
        {
            GameController.instance.roomsParent = Instantiate(roomsParentPrefab, Vector3.zero, Quaternion.identity);
            RoomSpawnStarter.instance.roomsParent = GameController.instance.roomsParent.transform;
        }

        if (!GameObject.FindGameObjectWithTag("Merchant Spawner"))
        {
            Instantiate(merchantSpawnerPrefab, Vector3.zero, Quaternion.identity, GameController.instance.roomsParent.transform);
        }

        Invoke("genLevel", 0.1f);
    }
    void genLevel()
    {
        if (hasSpawned == false )
        {
            if (doorDirection == 1)
            {
                if (!hasSpawned)
                {
                    rand = Random.Range(0, bottomRooms.Length);
                    GameController.instance.createdRooms.Add(Instantiate(bottomRooms[rand], transform.position, Quaternion.identity, GameController.instance.roomsParent.transform));
                    hasSpawned = true;
                    return;
                }
            }
            else if (doorDirection == 2)
            {
                if (!hasSpawned)
                {
                    rand = Random.Range(0, topRooms.Length);
                    GameController.instance.createdRooms.Add(Instantiate(topRooms[rand], transform.position, Quaternion.identity, GameController.instance.roomsParent.transform));
                    hasSpawned = true;
                    return;
                }
            }
            else if (doorDirection == 3)
            {
                if (!hasSpawned)
                {
                    rand = Random.Range(0, leftRooms.Length);
                    GameController.instance.createdRooms.Add(Instantiate(leftRooms[rand], transform.position, Quaternion.identity, GameController.instance.roomsParent.transform));
                    hasSpawned = true;
                    return;
                }
            }
            else if (doorDirection == 4)
            {
                if (!hasSpawned)
                {
                    rand = Random.Range(0, rightRooms.Length);
                    GameController.instance.createdRooms.Add(Instantiate(rightRooms[rand], transform.position, Quaternion.identity, GameController.instance.roomsParent.transform));
                    hasSpawned = true;
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string otherTag = collision.tag;

        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomGenerator>().hasSpawned == false && hasSpawned == false)
            {
                Instantiate(closedRoom, transform.position, Quaternion.identity, GameController.instance.roomsParent.transform);
                Destroy(gameObject);
            }
            hasSpawned = true;
        }
    }
}