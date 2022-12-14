using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "G")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "P")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "B")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "BG")
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "PG")
        {
            Destroy(gameObject);
        }

    }
}
