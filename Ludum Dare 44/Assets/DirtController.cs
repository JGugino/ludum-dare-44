using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    public int dirtHealth = 5;

    private void Update()
    {
        if (dirtHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodShot"))
        {
            Destroy(collision.gameObject);
            dirtHealth--;
        }
    }
}
