﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public string itemType = "none";

    [SerializeField]
    private SpriteRenderer itemIcon;

    [SerializeField]
    private Sprite[] possibleOrgans = new Sprite[4];

    [SerializeField]
    private Sprite[] possibleItems = new Sprite[1];

    public void setItemType(string _type)
    {
        if (_type != null)
        {
            itemType = _type;

            switch (_type)
            {
                case "lung":
                    itemIcon.sprite = possibleOrgans[0];
                    break;

                case "liver":
                    itemIcon.sprite = possibleOrgans[1];
                    break;

                case "kidney":
                    itemIcon.sprite = possibleOrgans[2];
                    break;

                case "heart":
                    itemIcon.sprite = possibleOrgans[3];
                    break;

                case "health":
                    itemIcon.sprite = possibleItems[0];
                    break;
            }
        }
    }
}