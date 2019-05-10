using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string otherTag = collision.tag;

        if (otherTag != "Destroyer")
        {
            if (otherTag == "CenterPoint")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
