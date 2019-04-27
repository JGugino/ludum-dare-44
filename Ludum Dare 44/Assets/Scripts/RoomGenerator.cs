using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    //1 - bottom door, 2 - top door, 3 - left door, 4 - right door
    public int doorDirection;

    [SerializeField]
    private GameObject[] bottomRooms = new GameObject[4], topRooms = new GameObject[4], leftRooms = new GameObject[4], rightRooms = new GameObject[4];


    public bool hasSpawned = false;

    private int maxRooms = 20;

    private int rand;

    public float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        Invoke("genLevel", 0.1f);
    }
    void genLevel()
    {
        if (hasSpawned == false && GameController.instance.createdRooms.ToArray().Length < maxRooms)
        {
            if (doorDirection == 1)
            {
                rand = Random.Range(0, bottomRooms.Length);
                GameController.instance.createdRooms.Add(Instantiate(bottomRooms[rand], transform.position, Quaternion.identity));
                hasSpawned = true;
            }
            else if (doorDirection == 2)
            {
                rand = Random.Range(0, topRooms.Length);
                GameController.instance.createdRooms.Add(Instantiate(topRooms[rand], transform.position, Quaternion.identity));
                hasSpawned = true;
            }
            else if (doorDirection == 3)
            {
                rand = Random.Range(0, leftRooms.Length);
                GameController.instance.createdRooms.Add(Instantiate(leftRooms[rand], transform.position, Quaternion.identity));
                hasSpawned = true;
            }
            else if (doorDirection == 4)
            {
                rand = Random.Range(0, rightRooms.Length);
                GameController.instance.createdRooms.Add(Instantiate(rightRooms[rand], transform.position, Quaternion.identity));
                hasSpawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string otherTag = collision.tag;

        if (collision.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}