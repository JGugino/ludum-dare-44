using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField]
    private GameObject openText;

    private string[] possibleItems = { "health", "liver", "heart", "lung", "kidney"};

    //private string[] possibleItems = { "health"};

    //private float interactRange = 3f;

    private float distance;

    private bool isOpen = false;

    //private void Update()
    //{
    //    if (GameController.instance.currentPlayer != null)
    //    {
    //        distance = Vector3.Distance(transform.position, GameController.instance.currentPlayer.position);
    //    }
    //}

    public void openChest()
    {
        if (!isOpen)
        {
            GameController.instance.createItem(possibleItems[Random.Range(0, possibleItems.Length)], transform.position);
            isOpen = true;
            gameObject.SetActive(false);
        }
    }
}
