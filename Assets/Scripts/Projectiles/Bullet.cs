using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Attackable>())
        {
            collision.gameObject.GetComponent<Attackable>().attacked(damage);
        }
        Destroy(gameObject);
    }
}
