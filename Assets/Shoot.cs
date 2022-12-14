using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform ShootPoint;
    public Transform Gun;
    public GameObject Bullet;
    public float BulletSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) ;
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns. transform. right * BulletSpeed);
    }
}
