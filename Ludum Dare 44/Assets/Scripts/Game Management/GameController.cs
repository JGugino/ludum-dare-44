using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject itemPrefab;

    public List<GameObject> createdRooms;

    public List<GameObject> createdItems;

    private int lungAmount = 0, liverAmount = 0, kidneyAmount = 0, heartAmount = 0;

    public bool isPaused = false;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void createItem(string _type, Vector3 _location , float _dropOffset = 1.4f)
    {
        GameObject current = Instantiate(GameController.instance.itemPrefab, new Vector3(_location.x + Random.Range(-_dropOffset, _dropOffset), _location.y + Random.Range(-_dropOffset, _dropOffset), _location.z), Quaternion.identity);
        current.GetComponent<ItemController>().setItemType(_type);
        createdItems.Add(current);
    }

    public void addOrgans(string _type, int amount)
    {
        switch (_type)
        {
            case "lung":
                lungAmount += amount;
                GUIController.instance.updateLungAmount();
                break;

            case "liver":
                liverAmount += amount;
                GUIController.instance.updateLiverAmount();
                break;

            case "kidney":
                kidneyAmount += amount;
                GUIController.instance.updateKidneyAmount();
                break;

            case "heart":
                heartAmount += amount;
                GUIController.instance.updateHeartAmount();
                break;
        }
    }

    public int getLungAmount()
    {
        return lungAmount;
    }

    public int getLiverAmount()
    {
        return liverAmount;
    }

    public int getKidneyAmount()
    {
        return kidneyAmount;
    }

    public int getHeartAmount()
    {
        return heartAmount;
    }
}
