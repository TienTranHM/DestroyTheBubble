using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Bubble" || coll.tag == "ResetBullet")
        {
            Destroy(bullet);    
        }
    }
}
