using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantSpawner : MonoBehaviour
{
    public static MerchantSpawner instance;

    private List<GameObject> possibleSpawns;

    public GameObject merchantPrefab;

    public GameObject ladderPrefab;

    public GameObject currentMerchant = null;

    private float merchantSpawnDelay = 2;
    public bool merchantSpawned = false;

    public bool findingNewSpawns = false;

    private void Awake()
    {
        instance = this;   
    }

    private void Start()
    {
        possibleSpawns = new List<GameObject>();

        findSpawns();
    }

    private void Update()
    {
        if (!merchantSpawned)
        {
            if (merchantSpawnDelay <= 0)
            {
                findSpawns();
                spawnMerchant();

                for (int i = 0; i < GameController.instance.createdRooms.Count; i++)
                {
                    if (i == GameController.instance.createdRooms.Count -1)
                    {
                        GameController.instance.lastRoom = GameController.instance.createdRooms[i];

                          //Instantiate(ladderPrefab,
                          //GameController.instance.createdRooms[i].GetComponentInChildren<CenterPoint>().gameObject.transform.position, 
                          //Quaternion.identity, GameController.instance.roomsParent.transform);

                        merchantSpawned = true;
                    }
                }
            }
            else
            {
                merchantSpawnDelay -= Time.deltaTime;
            }
        }
    }

    public void findSpawns()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Merchant Spawn");

        for (int i = 0; i < objects.Length; i++)
        {
            possibleSpawns.Add(objects[i]);
        }
    }

    public void spawnMerchant()
    {
        if (possibleSpawns.Count > 0)
        {
            if (currentMerchant == null)
            {
                Transform pickedSpawn = possibleSpawns[Random.Range(0, possibleSpawns.ToArray().Length)].GetComponent<Transform>();

                currentMerchant = Instantiate(merchantPrefab, pickedSpawn.position, Quaternion.identity,
                    GameController.instance.roomsParent.transform);
            }

        }
    }

    public void removeOldPoints()
    {
        for (int i = 0; i < possibleSpawns.Count; i++)
        {
            possibleSpawns.Remove(possibleSpawns[i]);
        }
    }

    public List<GameObject> getPossibleSpawns()
    {
        return possibleSpawns;
    }
}
