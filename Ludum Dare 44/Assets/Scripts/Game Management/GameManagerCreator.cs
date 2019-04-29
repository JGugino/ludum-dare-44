using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCreator : MonoBehaviour
{
    public GameObject _gameManagerPrefab;
    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") == null)
        {
            Instantiate(_gameManagerPrefab);
            return;
        }
        else
        {
            return;
        }
    }

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1);

        GUIController.instance.findMenuUI();
    }
}
