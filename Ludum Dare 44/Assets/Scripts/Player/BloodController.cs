using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{
    public float offset = 10;

    public float bloodSpeed = 1500f;

    public Vector3 _dest = Vector3.zero;

    private float destroyDelay = 1f;


    private void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_dest.x, _dest.y, 0), bloodSpeed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tile"))
        {
            Destroy(gameObject);
        }
    }
}
