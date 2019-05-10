using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnStarter : MonoBehaviour
{
    public static RoomSpawnStarter instance;

    public GameObject startRoomPrefab;

    public Transform currentStartRoom;

    public Transform roomsParent;

    private void Awake()
    {
        instance = this;
    }

    public void spawnStartRoom()
    {
        if (!GameObject.FindGameObjectWithTag("Start Room"))
        {
            currentStartRoom = Instantiate(startRoomPrefab, transform.position, Quaternion.identity, roomsParent).transform;
        }
    }
}
