using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCreator : MonoBehaviour
{
    public GameObject _gameManagerPrefab, audioManagerPrefab;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") == null)
        {
            Instantiate(_gameManagerPrefab);

            if (GameObject.FindGameObjectWithTag("AudioManager") == null)
            {
                Instantiate(audioManagerPrefab);
            }

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
