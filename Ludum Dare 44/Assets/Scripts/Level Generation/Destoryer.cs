using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string otherTag = collision.tag;

        if (otherTag != "Player" && otherTag != "BloodShot")
        {
            Destroy(collision.gameObject);
        }

        if (otherTag == "CenterPoint")
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
