using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject itemPrefab;

    public GameObject upgradeIconPrefab;

    public List<GameObject> createdRooms;

    public List<GameObject> createdItems;

    private int lungAmount = 0, liverAmount = 0, kidneyAmount = 0, heartAmount = 0;

    public bool isPaused = false;

    public GameObject roomsParent;

    public Transform currentPlayer;

    public GameObject lastRoom = null;

    [SerializeField]
    private int currentLevel = 1;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    #region Init start game
    public void startGame()
    {
        SceneManager.LoadScene("main_game");
        StartCoroutine(lateStart());
    }

    private IEnumerator lateStart()
    {
        yield return new WaitForSeconds(1f);
        GUIController.instance.findGameUI();

        RoomSpawnStarter.instance.spawnStartRoom();

        PlayerSpawner.instance.spawnPlayer();
        GUIController.instance.toggleLoadingScreen(false);
    }
    #endregion

    public void resumeGame()
    {
        GUIController.instance.togglePauseScreen(false);
        isPaused = false;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void exitToMenu()
    {
        GUIController.instance.toggleLoadingScreen(true);

        for (int i = 0; i < createdRooms.Count; i++)
        {
            createdRooms.Remove(createdRooms[i]);
        }

        Destroy(roomsParent);

        lungAmount = 0;
        liverAmount = 0;
        kidneyAmount = 0;
        heartAmount = 0;

        SceneManager.LoadScene("main_menu");
    }

    #region Create new rooms
    public void createNewRooms()
    {
        GUIController.instance.toggleLoadingScreen(true);

        currentPlayer.gameObject.SetActive(false);

        for (int i = 0; i < createdRooms.Count; i++)
        {
            createdRooms.Remove(createdRooms[i]);
        }

        Destroy(roomsParent);

        Destroy(RoomSpawnStarter.instance.currentStartRoom.gameObject);

        currentLevel++;

        StartCoroutine(roomCreateWait());
    }

    private IEnumerator roomCreateWait()
    {
        yield return new WaitForSeconds(1);

        RoomSpawnStarter.instance.spawnStartRoom();

        currentPlayer.position = PlayerSpawner.instance.playerSpawn.position;

        currentPlayer.gameObject.SetActive(true);

        GUIController.instance.toggleDeathScreen(false);

        yield return new WaitForSeconds(0.5f);

        GUIController.instance.toggleLoadingScreen(false);
    }
    #endregion

    public void createItem(string _type, Vector3 _location , float _dropOffset = 1.4f)
    {
        GameObject current = Instantiate(GameController.instance.itemPrefab, new Vector3(_location.x + Random.Range(-_dropOffset, _dropOffset), _location.y + Random.Range(-_dropOffset, _dropOffset), _location.z), Quaternion.identity, roomsParent.transform);
        current.GetComponent<ItemController>().setItemType(_type);
        createdItems.Add(current);
    }

    public void createUpgradeIcon(Sprite upgradeIcon)
    {
        GameObject go = Instantiate(upgradeIconPrefab, GUIController.instance.getUpgradeIconsParent());

        go.GetComponent<Image>().sprite = upgradeIcon;
    }

    #region Organ Controls
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

    public void removeOrgans(string _type, int _amount)
    {
        switch (_type)
        {
            case "lung":
                lungAmount -= _amount;

                GUIController.instance.updateLungAmount();
                break;

            case "liver":
                liverAmount -= _amount;
                GUIController.instance.updateLiverAmount();
                break;

            case "kidney":
                kidneyAmount -= _amount;
                GUIController.instance.updateKidneyAmount();
                break;

            case "heart":
                heartAmount -= _amount;
                GUIController.instance.updateHeartAmount();
                break;
        }
    }
    #endregion

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

    public int getCurrentLevel()
    {
        return currentLevel;
    }
}
