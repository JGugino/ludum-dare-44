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
    private bool merchantSpawned = false;

    private void Awake()
    {
        instance = this;   
    }

    private void Start()
    {
        possibleSpawns = new List<GameObject>();

        findSpawns();
        //Invoke("spawnMerchant", 0.1f);
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
                        Instantiate(ladderPrefab, GameController.instance.createdRooms[i].GetComponentInChildren<CenterPoint>().gameObject.transform.position, Quaternion.identity);
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
        //Debug.Log(possibleSpawns.ToArray().Length);

        Transform pickedSpawn = possibleSpawns[Random.Range(0, possibleSpawns.ToArray().Length)].GetComponent<Transform>();

        currentMerchant = Instantiate(merchantPrefab, pickedSpawn.position, Quaternion.identity);
    }
}
