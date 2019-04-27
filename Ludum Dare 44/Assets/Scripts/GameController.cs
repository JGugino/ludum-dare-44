using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public List<GameObject> createdRooms;

    private void Awake()
    {
        instance = this;
    }
}
