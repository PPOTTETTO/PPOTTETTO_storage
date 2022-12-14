using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUMP : MonoBehaviour
{

    public float B;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P"));
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * B, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("B")) ;
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * B, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("D")) ;
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * B, ForceMode2D.Impulse);
        }

    }
}
