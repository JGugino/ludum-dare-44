using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public static HealthController instance;

    public GameObject heartPrefab;

    public List<GameObject> spawnedHearts;

    public Transform heartContainer;

    private void Awake()
    {
        instance = this;
    }

    public void addHeart(int heartsToAdd)
    {
        for (int i = 0; i < heartsToAdd; i++)
        {
            spawnedHearts.Add(Instantiate(heartPrefab, heartContainer));
        }
    }

    public void removeHearts(int heartsToRemove)
    {
        for (int i = 0; i < heartsToRemove; i++)
        {
            Destroy(spawnedHearts[i], .5f);
            spawnedHearts.Remove(spawnedHearts[i]);
        }
    }
}
