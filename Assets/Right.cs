using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{

     public float BL;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P")) ;
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * BL, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("B")) ;
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * BL, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("D")) ;
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * BL, ForceMode2D.Impulse);
        }

    }
}
